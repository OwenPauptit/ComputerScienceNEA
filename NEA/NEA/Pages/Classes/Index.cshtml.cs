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

        public class ClassroomIndexVM
        {
            public string ID { get; set; }
            public string Name { get; set; }
            public string Teacher { get; set; }
            public int StudentCount { get; set; }
        }

        public async Task OnGetAsync()
        {
            ClassroomVM = new List<ClassroomIndexVM>();
            IList<Classroom> classroom;

            if (User.IsInRole(Constants.StudentRole))
            {
                var userEnrollments = (from e in Context.Enrollments
                                       select e)
                                      .Where(e => e.NEAUserId == UserManager.GetUserId(User));

                var classIDs = await (from e in userEnrollments
                                      select e.ClassroomID)
                                      .AsNoTracking()
                                      .ToListAsync();


                classroom = await Context.Classrooms
                    .Include(c => c.Teacher)
                    .Where(c => classIDs.Contains(c.ClassroomID))
                    .ToListAsync();

            }
            else
            {
                classroom = await Context.Classrooms
                    .Include(c => c.Teacher)
                    .Where(c => c.UserID == UserManager.GetUserId(User))
                    .ToListAsync();
            }

            foreach (var item in classroom)
            {
                List<Enrollment> students = await Context.Enrollments
                            .Where(e => e.ClassroomID == item.ClassroomID)
                            .AsNoTracking()
                            .ToListAsync();

                ClassroomVM.Add(
                    new ClassroomIndexVM
                    {
                        ID = item.ClassroomID,
                        Name = item.Name,
                        Teacher = item.Teacher.LastName + ", " + item.Teacher.FirstName,
                        StudentCount = students.Count()
                    }
                ) ;
            }
        }
    }
}
