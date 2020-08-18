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

namespace NEA.Pages.Enrollments
{
    public class DeleteModel : DI_BasePageModel
    {
        public DeleteModel(
        NEAContext context,
        IAuthorizationService authorizationService,
        UserManager<NEAUser> userManager)
        : base(context, authorizationService, userManager)
        {
        }

        [BindProperty]
        public Enrollment Enrollment { get; set; }

        public async Task<IActionResult> OnGetAsync(string classId)
        {
            if (classId == null)
            {
                return NotFound();
            }

            var id = UserManager.GetUserId(User);

            Enrollment = await Context.Enrollments
                .Include(e => e.Classroom)
                    .ThenInclude(e => e.Teacher)
                .Include(e => e.NEAUser)
                .Where(m => m.ClassroomID == classId)
                .FirstOrDefaultAsync(m => m.NEAUserId == id);

            if (Enrollment == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string classId)
        {
            if (classId == null)
            {
                return NotFound();
            }

            var id = UserManager.GetUserId(User);

            Enrollment = await Context.Enrollments
                .Where(m => m.ClassroomID == classId)
                .FirstOrDefaultAsync(m => m.NEAUserId == id);

            if (Enrollment != null)
            {
                Context.Enrollments.Remove(Enrollment);
                await Context.SaveChangesAsync();
            }

            return RedirectToPage("/Classes/Index");
        }
    }
}
