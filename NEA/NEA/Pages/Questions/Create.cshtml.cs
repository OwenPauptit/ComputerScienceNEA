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
                    Correct = false
                };

                var question = Questions.Single(q => q.QIndex == studentQuestion.QIndex);
                var answerList = question.AnswerString.Split('/');

                switch (question.QuestionType.Name)
                {
                    case "Multiple Choice": case "TrueFalse":


                        if (studentQuestion.Answer == answerList[0])
                        {
                            score++;
                            studentQuestion.Correct = true;
                        }

                        break;

                    case "Calculation":
                        float answer, lenience, studentAnswer;

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
                        if (answerList[2] == "null")
                        {
                            if (studentAnswer > answer - lenience && studentAnswer < answer + lenience)
                            {
                                score++;
                                studentQuestion.Correct = true;
                            }
                        }
                        else
                        {
                            break;
                        }

                        break;

                }

                if (studentQuestion.Answer == Questions.Single(q => q.QIndex == studentQuestion.QIndex).AnswerString.Split('/')[0])
                {
                    score++;
                    studentQuestion.Correct = true;
                }

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

            return RedirectToPage("/Classes/Index");
        }
    }
}
