
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

                    foreach (var item in studentQuestions)
                    {
                        var student = students.Single(s => s.Id == item.UserID);

                        var isAuthorized = await AuthorizationService.AuthorizeAsync(User, item, Operations.ViewStudentAssignment);

                        if (!isAuthorized.Succeeded)
                        {
                            var enrollment = Context.Enrollments
                                .Include(e => e.Classroom)
                                .ThenInclude(e => e.Teacher)
                                .AsNoTracking()
                                .SingleOrDefault(e => e.NEAUserId == item.UserID && e.ClassroomID == ClassID);

                            isAuthorized = await AuthorizationService.AuthorizeAsync(User, enrollment, Operations.ViewStudentAssignment);

                            if (!isAuthorized.Succeeded)
                            {
                                continue;
                            }
                        }
                        studentQuestionsVM.Add(
                            new StudentQuestionVM
                            {
                                QIndex = item.QIndex,
                                StudentName = student.FirstName + " " + student.LastName,
                                Answer = item.Answer,
                                isCorrect = item.isCorrect
                            });

                    }

                    ClassroomData.StudentQuestions = studentQuestionsVM;

                }

            }

           


        }
    }
}
