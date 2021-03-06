﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NEA.Authorization;
using NEA.Areas.Identity.Data;
using NEA.Models;
using Microsoft.AspNetCore.Authorization;
using NEA.Models.ViewModels;

namespace NEA.Pages.Classes
{
    public class IndexModel : DI_BasePageModel
    {
        public IndexModel(
        NEAContext context,
        IAuthorizationService authorizationService,
        UserManager<NEAUser> userManager)
        : base(context, authorizationService, userManager)
        {
        }

        public IList<ClassroomIndexVM> ClassroomVM { get; set; }
        public ClassroomIndexData ClassroomData { get; set; }

        public string ClassID { get; set; }
        public int SimulatorID { get; set; }
        public bool ShowDetails { get; set; }

        [BindProperty]
        public StudentQuestion StudentQuestion { get; set; }

        public async Task OnGetAsync(string classId, int? simId, bool? showDetails)
        {
            ClassroomData = new ClassroomIndexData();
            


            if (User.IsInRole(Constants.StudentRole))
            {
                var userEnrollments = (from e in Context.Enrollments
                                       select e)
                                      .Where(e => e.NEAUserId == UserManager.GetUserId(User));

                var classIDs = await (from e in userEnrollments
                                      select e.ClassroomID)
                                      .AsNoTracking()
                                      .ToListAsync();

                ClassroomData.Classrooms = await Context.Classrooms
                    .Include(c => c.Teacher)
                    .Include(c => c.Enrollments)
                        .ThenInclude(c => c.NEAUser)
                            .ThenInclude(c => c.StudentAssignments)
                    .Include(c => c.Enrollments)
                        .ThenInclude(c => c.NEAUser)
                            .ThenInclude(c => c.StudentQuestions)
                    .Include(c => c.ClassAssignments)
                        .ThenInclude(c => c.Simulation)
                            .ThenInclude(c => c.Questions)
                    .Where(c => classIDs.Contains(c.ClassroomID))
                    .AsNoTracking()
                    .ToListAsync();


            }
            else
            {
                ClassroomData.Classrooms = await Context.Classrooms
                    .Include(c => c.Teacher)
                    .Include(c => c.Enrollments)
                        .ThenInclude(c => c.NEAUser)
                            .ThenInclude(c => c.StudentAssignments)
                    .Include(c => c.Enrollments)
                        .ThenInclude(c => c.NEAUser)
                            .ThenInclude(c => c.StudentQuestions)
                    .Include(c => c.ClassAssignments)
                        .ThenInclude(c => c.Simulation)
                            .ThenInclude(c => c.Questions)
                    .Where(c => c.UserID == UserManager.GetUserId(User))
                    .AsNoTracking()
                    .ToListAsync();
            }


            /*foreach (var item in classroom)
            {
                List<Enrollment> students = await Context.Enrollments
                            .Where(e => e.ClassroomID == item.ClassroomID)
                            .AsNoTracking()
                            .ToListAsync();

                ClassroomVM.Add(
                    new ClassroomVM
                    {
                        ID = item.ClassroomID,
                        Name = item.Name,
                        Teacher = item.Teacher.LastName + ", " + item.Teacher.FirstName,
                        StudentCount = students.Count()
                    }
                ) ;
            }*/

            if (classId != null)
            {
                ClassID = classId;
                Classroom classroom = ClassroomData.Classrooms.Where(c => c.ClassroomID == ClassID).SingleOrDefault();
                if (classroom == null)
                {
                    return;
                }
                ClassroomData.ClassAssignments = classroom.ClassAssignments.Select(c => c);
            }

            if (simId != null)
            {
                SimulatorID = simId.Value;
                ClassAssignment assignment = ClassroomData.ClassAssignments.Where(c => c.SimulationID == SimulatorID).SingleOrDefault();
                if (assignment == null)
                {
                    return;
                }
                
                if (User.IsInRole(Constants.StudentRole))
                {
                    NEAUser thisuser = ClassroomData.Classrooms
                        .Single(c => c.ClassroomID == ClassID)
                            .Enrollments
                                .Single(e => e.NEAUserId == UserManager.GetUserId(User))
                                    .NEAUser;

                    StudentAssignment? studentAssignment = thisuser
                                        .StudentAssignments
                                            .SingleOrDefault(s => s.SimulationID == SimulatorID);


                    ClassroomData.StudentAssignments = new List<StudentAssignmentIndexVM> 
                    {
                        new StudentAssignmentIndexVM
                        {
                            StudentName = thisuser.LastName + ", " + thisuser.FirstName,
                            Percentage = studentAssignment?.Percentage,
                            DateCompleted = studentAssignment?.DateCompleted,
                            SimulationID = SimulatorID
                        } 
                    };

                }
                else
                {
                    var enrollments = ClassroomData.Classrooms
                        .Single(c => c.ClassroomID == ClassID)
                            .Enrollments;

                    var students = from e in enrollments
                                   select e.NEAUser;

                    var studentAssignments = new List<StudentAssignmentIndexVM>();

                    foreach(var item in students)
                    {
                        var studentAssignment = item.StudentAssignments.SingleOrDefault(s => s.SimulationID == SimulatorID);

                        studentAssignments.Add(new StudentAssignmentIndexVM()
                        {
                            StudentName = item.LastName + ", " + item.FirstName,
                            Percentage = studentAssignment?.Percentage,
                            DateCompleted = studentAssignment?.DateCompleted,
                            SimulationID = SimulatorID
                        });
                    }

                    ClassroomData.StudentAssignments = studentAssignments;
                }

                if (showDetails != null && showDetails == true)
                {
                    ShowDetails = showDetails.Value;

                    ClassroomData.Questions = await Context.Questions
                        .Where(s => s.SimulationID == SimulatorID)
                        .AsNoTracking()
                        .ToListAsync();

                    List<NEAUser> students = await (from e in Context.Enrollments
                                                    where e.ClassroomID == ClassID
                                                    select e.NEAUser)
                                                   .AsNoTracking()
                                                   .ToListAsync();

                    List<StudentQuestion> studentQuestions = await Context.StudentQuestions
                        .Include(s => s.NEAUser)
                            .ThenInclude(s => s.Enrollments)
                        .Where(s => s.SimulationID == SimulatorID)
                        .AsNoTracking()
                        .ToListAsync();

                    

                    var studentQuestionsVM = new List<StudentQuestionVM>();

                    

                    foreach (var student in students)
                    {
                        var thisStudentsQuestions = studentQuestions.Where(s => s.UserID == student.Id);

                        foreach(var question in ClassroomData.Questions)
                        {

                            var studentQuestion = thisStudentsQuestions.SingleOrDefault(s => s.QIndex == question.QIndex);

                            if (studentQuestion == null)
                            {
                                studentQuestion = new StudentQuestion
                                {
                                    QIndex = question.QIndex,
                                    SimulationID = SimulatorID,
                                    Answer = "",
                                    isCorrect = AnswerType.Unanswered
                                };
                            }

                            var isAuthorized = await AuthorizationService.AuthorizeAsync(User, studentQuestion, Operations.ViewStudentAssignment);

                            if (!isAuthorized.Succeeded)
                            {
                                var enrollment = Context.Enrollments
                                    .Include(e => e.Classroom)
                                    .ThenInclude(e => e.Teacher)
                                    .AsNoTracking()
                                    .SingleOrDefault(e => e.NEAUserId == student.Id && e.ClassroomID == ClassID);

                                isAuthorized = await AuthorizationService.AuthorizeAsync(User, enrollment, Operations.ViewStudentAssignment);

                                if (!isAuthorized.Succeeded)
                                {
                                    continue;
                                }
                            }
                            studentQuestionsVM.Add(
                                new StudentQuestionVM
                                {
                                    UserId = student.Id,
                                    QIndex = studentQuestion.QIndex,
                                    StudentName = student.FirstName + " " + student.LastName,
                                    Answer = studentQuestion.Answer,
                                    isCorrect = studentQuestion.isCorrect,
                                    SimID = SimulatorID
                                });

                        }

                    }

                    ClassroomData.StudentQuestions = studentQuestionsVM;

                }

            }

           


        }

        public async Task<IActionResult> OnPostOverride(string classid)
        {
            //if(String.IsNullOrEmpty(id) || qindex == null || simid == null|| classid == null)

            StudentQuestion studentQuestion = Context.StudentQuestions
                .SingleOrDefault(s => s.UserID == StudentQuestion.UserID
                                 && s.QIndex == StudentQuestion.QIndex
                                 && s.SimulationID == StudentQuestion.SimulationID);

            if (studentQuestion == null || studentQuestion.isCorrect == AnswerType.Unanswered)
            {
                return RedirectToPage("./index", new { classId = classid, simId = studentQuestion.SimulationID, showDetails = true });
            }

           // var id = stuquest.AuthorizeAccessToID(Context.Users.Single(u => u.Id == UserManager.GetUserId(User)), Context, classid);


            /*if (String.IsNullOrEmpty(id))
            {
                return Page();
            }*/

            /*StudentQuestion studentQuestion = Context.StudentQuestions
                .Where(s => s.UserID == id)
                .Where(s => s.QIndex == qindex)
                .SingleOrDefault(s => s.SimulationID == simid);

            if (studentQuestion == null)
            {
                return RedirectToPage("./index");
            }*/

            var enrollment = Context.Enrollments
                .Include(e => e.Classroom)
                .SingleOrDefault(e => e.NEAUserId == studentQuestion.UserID && e.ClassroomID == classid);

            if (enrollment == null)
            {
                return RedirectToPage("./index", new { classId = classid, simId = studentQuestion.SimulationID, showDetails = true });
            }

            var isAuthorized = await AuthorizationService.AuthorizeAsync(User, enrollment, Operations.OverrideStudentAssignment);

            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            Context.StudentQuestions.Remove(studentQuestion);
            Context.SaveChanges();


            if (studentQuestion.isCorrect == AnswerType.Incorrect
                || studentQuestion.isCorrect == AnswerType.OverriddenIncorrect)
            {
                studentQuestion.isCorrect = AnswerType.OverriddenCorrect;
            }
            else
            {
                studentQuestion.isCorrect = AnswerType.OverriddenIncorrect;
            }

            Context.StudentQuestions.Add(studentQuestion);
            Context.SaveChanges();

            return RedirectToPage("./index", new { classId = classid, simId = studentQuestion.SimulationID, showDetails = true});
        }

    }
}
