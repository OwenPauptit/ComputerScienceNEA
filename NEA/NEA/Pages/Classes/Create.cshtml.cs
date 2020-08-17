using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NEA.Areas.Identity.Data;
using NEA.Authorization;
using NEA.Models;
using NEA.Models.ViewModels;

namespace NEA.Pages.Classes
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

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ClassroomCRUDVM ClassroomCRUDVM { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var emptyClassroom = new Classroom();
            emptyClassroom.Name = ClassroomCRUDVM.Name;
            emptyClassroom.UserID = UserManager.GetUserId(User);

            // Ensuring User is authorized to create a new classroom
            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                        User, emptyClassroom,
                                                        Operations.CreateClass);
            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }


                Context.Classrooms.Add(emptyClassroom);
                await Context.SaveChangesAsync();
                return RedirectToPage("./Index");

            return Page();

        }
    }
}
