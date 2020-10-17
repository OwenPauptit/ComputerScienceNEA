using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NEA.Areas.Identity.Data;
using NEA.Models;
using NEA.Authorization;

namespace NEA.Pages.Classes
{
    public class DetailsModel : DI_BasePageModel
    {
        public DetailsModel(
        NEAContext context,
        IAuthorizationService authorizationService,
        UserManager<NEAUser> userManager)
        : base(context, authorizationService, userManager)
        {
        }

        public Classroom Classroom { get; set; }

        public List<string> Students { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Classroom = await Context.Classrooms
                .Include(c => c.Teacher)
                .Include(c => c.Enrollments)
                .FirstOrDefaultAsync(m => m.ClassroomID == id);

            var enrollments = await Context.Enrollments
                .Include(e => e.Classroom)
                .Include(e => e.NEAUser)
                .Where(e => e.ClassroomID == id)
                .ToListAsync();

            Students = (from e in enrollments
                       select (e.NEAUser.LastName + ", " + e.NEAUser.FirstName))
                       .ToList();

            /*foreach (var e in enrollments)
            {
                var isAuthorized = await AuthorizationService.AuthorizeAsync(User, e, Operations.ViewStudentAssignment);

                if (isAuthorized.Succeeded)
                {
                    Students.Add(e.NEAUser.LastName + ", " + e.NEAUser.FirstName);
                }
            }*/


            if (Classroom == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
