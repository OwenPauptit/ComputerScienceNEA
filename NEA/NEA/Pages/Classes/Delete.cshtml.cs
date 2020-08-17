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
using NEA.Authorization;
using NEA.Models;
using NEA.Models.ViewModels;

namespace NEA.Pages.Classes
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
        public Classroom Classroom { get; set; }

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

            if (Classroom == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Classroom = await Context.Classrooms.FindAsync(id);

            // Ensuring User is authorized to create a new classroom
            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                        User, Classroom,
                                                        Operations.DeleteClass);
            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            if (Classroom != null)
            {
                Context.Classrooms.Remove(Classroom);
                await Context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
