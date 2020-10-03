
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
                    //ClassroomData.Questions = (from c in ClassroomData.Classrooms
                      //                         where c.ClassAssignments.
                        //                      select c.ClassAssignments)
                }

            }


        }
    }
}
