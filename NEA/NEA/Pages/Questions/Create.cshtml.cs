using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NEA.Areas.Identity.Data;
using NEA.Models;

namespace NEA.Pages.Questions
{
    public class CreateModel : DI_BasePageModel
    {
        public CreateModel(
        NEAContext context,
        IAuthorizationService authorizationService,
        UserManager<NEAUser> userManager)
        : base(context, authorizationService, userManager)
        {
        }

        public async Task<IActionResult> OnGet(int? simID)
        {

            if(simID == null)
            {
                return NotFound();
            }

            Questions = await Context.Questions
                .Include(q => q.Simulation)
                .Include(q => q.QuestionType)
                .Include(q => q.StudentQuestions)
                .Where(q => q.SimulationID == simID)
                .ToListAsync();

            if (Questions == null || Questions.Count() == 0)
            {
                return NotFound();
            }

            StudentAnswers = new string[Questions.Count()];

            return Page();
        }

        [BindProperty]
        public string[] StudentAnswers { get; set; }
        public List<Question> Questions { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? simID)
        {
            if (StudentAnswers == null)
            {
                return NotFound();
            }
            if (simID == null)
            {
                return NotFound();
            }

            Questions = await Context.Questions
                .Include(q => q.QuestionType)
                .Include(q => q.StudentQuestions)
                .Where(q => q.SimulationID == simID.Value)
                .ToListAsync();


            int score = 0;
            for (int i = 0; i < StudentAnswers.Length; i++)
            {
                var studentQuestion = new StudentQuestion
                {
                    Answer = StudentAnswers[i],
                    UserID = UserManager.GetUserId(User),
                    SimulationID = simID.Value,
                    QIndex = i + 1,
                    isCorrect = AnswerType.Incorrect
                };

                var question = Questions.Single(q => q.QIndex == studentQuestion.QIndex);
                var answerList = question.AnswerString.Split(';');

                switch (question.QuestionType.Name)
                {
                    case "Multiple Choice": case "TrueFalse":


                        if (studentQuestion.Answer == answerList[0])
                        {
                            score++;
                            studentQuestion.isCorrect = AnswerType.Correct;
                        }

                        break;

                    case "Calculation":
                        float answer, lenience, studentAnswer;
                        float? temp;

                        if (!float.TryParse(answerList[0], out answer))
                        {
                            break;
                        }
                        if (!float.TryParse(studentQuestion.Answer, out studentAnswer))
                        {
                            break;
                        }
                        if (!float.TryParse(answerList[1], out lenience))
                        {
                            lenience = 0f;
                        }
                        if (studentAnswer >= answer - lenience && studentAnswer <= answer + lenience)
                            {
                                score++;
                                studentQuestion.isCorrect = AnswerType.Correct;
                            }
                        else if (answerList[2] != null)
                        {
                            temp = EvaluatePostFixExp(answerList[2]);
                            if (temp != null)
                            {
                                answer = temp.Value;
                                if (studentAnswer > answer - lenience && studentAnswer < answer + lenience)
                                {
                                    score++;
                                    studentQuestion.isCorrect = AnswerType.ErrorCarriedForward;
                                }
                            }
                        }

                        break;

                }

                //if (studentQuestion.Answer == Questions.Single(q => q.QIndex == studentQuestion.QIndex).AnswerString.Split('/')[0])
                //{
                //    score++;
                //    studentQuestion.Correct = true;
                //}

                var existigSQ = Context.StudentQuestions
                .SingleOrDefault(m => m.UserID == UserManager.GetUserId(User)
                    && m.SimulationID == simID 
                    && m.QIndex == i + 1);

                if (existigSQ != null)
                {
                    Context.Remove(existigSQ);
                    await Context.SaveChangesAsync();
                }

                Context.StudentQuestions.Add(studentQuestion);
                await Context.SaveChangesAsync();
            }

            StudentAssignment s = Context.StudentAssignments
                .SingleOrDefault(s => s.SimulationID == Questions[0].SimulationID &&
                    s.UserID == UserManager.GetUserId(User));

            if (s == null)
            {
                s = new StudentAssignment
                {
                    UserID = UserManager.GetUserId(User),
                    SimulationID = simID.Value
                };
            }
            s.DateCompleted = DateTime.Now.Date;
            s.Percentage = (int)(100 * score / Questions.Count());

            Context.Attach(s).State = EntityState.Modified;

            try
            {
                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return RedirectToPage("./Details",new { simID = simID.Value });
        }

        private float? EvaluatePostFixExp(string exp)
        {
            Stack<float> stack = new Stack<float>();

            List<string> operators = new List<string>() { "+", "-", "*", "/", "^" };

            List<string> expression = exp.Split('|').ToList();

            int index;

            float operand1, operand2, result;

            for (int i = 0; i < expression.Count(); i++)
            {
                if (operators.Contains(expression[i]))
                {
                    if (stack.Count() < 2)
                    {
                        return null;
                    }
                    operand2 = stack.Pop();
                    operand1 = stack.Pop();

                    switch (expression[i])
                    {
                        case "+":
                            result = operand1 + operand2;
                            break;
                        case "-":
                            result = operand1 - operand2;
                            break;
                        case "*":
                            result = operand1 * operand2;
                            break;
                        case "/":
                            result = operand1 / operand2;
                            break;
                        case "^":
                            result = (float)Math.Pow(operand1, operand2);
                            break;
                        default:
                            return null;
                    }

                    stack.Push(result);
                }
                else
                {

                    if (expression[i][0] == '#')
                    {
                        index = new int();
                        if (!Int32.TryParse(expression[i].Substring(1), out index))
                        {
                            return null;
                        }
                        operand1 = new float();
                        if (!float.TryParse(StudentAnswers[index - 1], out operand1))
                        {
                            return null;
                        }
                    }
                    else
                    {
                        operand1 = new float();
                        if (!float.TryParse(expression[i], out operand1))
                        {
                            return null;
                        }
                    }
                    stack.Push(operand1);
                }
            }

            return stack.Pop();
        }


    }
}
