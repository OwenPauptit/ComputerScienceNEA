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
using NEA.Authorization;
using NEA.Models;
using NEA.Models.ViewModels;

namespace NEA.Pages.Classes
{
    public class EditModel : DI_BasePageModel
    {
        public EditModel(
        NEAContext context,
        IAuthorizationService authorizationService,
        UserManager<NEAUser> userManager)
        : base(context, authorizationService, userManager)
        {
        }

        [BindProperty]
        public ClassroomCRUDVM ClassroomCRUDVM { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classroom = await Context.Classrooms
                .Include(c => c.Teacher).FirstOrDefaultAsync(m => m.ClassroomID == id);

            if (classroom == null)
            {
                return NotFound();
            }
            ClassroomCRUDVM = new ClassroomCRUDVM();
            ClassroomCRUDVM.Name = classroom.Name;
            ClassroomCRUDVM.ClassroomID = classroom.ClassroomID;

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var classroom = await Context.Classrooms
                .Include(c => c.Teacher)
                .FirstOrDefaultAsync(m => m.ClassroomID == ClassroomCRUDVM.ClassroomID);

            // Ensuring User is authorized to edit the classroom
            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                        User, classroom,
                                                        Operations.EditClass);
            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            classroom.Name = ClassroomCRUDVM.Name;

                try
                {
                    await Context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassroomExists(classroom.ClassroomID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToPage("./Index");

            

            return Page();
        }

        private bool ClassroomExists(string id)
        {
            return Context.Classrooms.Any(e => e.ClassroomID == id);
        }
    }
}
