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
using NEA.Models;
using NEA.Authorization;
using NEA.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace NEA.Pages.Enrollments
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

        public async Task<IActionResult> OnGet(string id)
        {
            if (id != null)
            {
                return await Enroll(id);
            }
            return Page();
        }

        [BindProperty]
        public EnrollmentVM EnrollmentVM { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            return await Enroll(EnrollmentVM.ClassroomID);
        }

        public async Task<IActionResult> Enroll(string id)
        {
            Classroom classroomToJoin = Context.Classrooms
                .Include(c => c.Enrollments)
                .SingleOrDefault(c => c.ClassroomID == id);

            if (classroomToJoin == null)
            {
                return NotFound();
            }

            var isAuthorized = await AuthorizationService.AuthorizeAsync
                (User, classroomToJoin, Operations.Enroll);
            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            var enrollment = new Enrollment
            {
                NEAUserId = UserManager.GetUserId(User),
                ClassroomID = classroomToJoin.ClassroomID
            };

            Context.Enrollments.Add(enrollment);
            await Context.SaveChangesAsync();

            return RedirectToPage("../Classes/Index");
        }
    }
}
