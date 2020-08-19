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

namespace NEA.Pages.StudentAssignments
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

        public IActionResult OnGet(int? simId)
        {
            if (simId == null)
            {
                return NotFound();
            }

            StudentAssignment = Context.StudentAssignments
                .SingleOrDefault(m => m.UserID == UserManager.GetUserId(User) && m.SimulationID == simId.Value);

            if (StudentAssignment == null)
            {
                if (!SimulationExists(simId.Value))
                {
                    return NotFound();
                }

                StudentAssignment = new StudentAssignment
                {
                    SimulationID = simId.Value
                };
            }

            return Page();
        }

        [BindProperty]
        public StudentAssignment StudentAssignment { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            StudentAssignment.DateCompleted = DateTime.Now;
            StudentAssignment.UserID = UserManager.GetUserId(User);
            StudentAssignment.SimulationID = StudentAssignment.SimulationID;

            var isAuthorized = await AuthorizationService.AuthorizeAsync(User, StudentAssignment, Operations.CompleteAssignment);
             if(!isAuthorized.Succeeded)
            {
                return Forbid();
            }


            var existigSA = Context.StudentAssignments
                .SingleOrDefault(m => m.UserID == UserManager.GetUserId(User)
                && m.SimulationID == StudentAssignment.SimulationID);

            if (existigSA != null)
            {
                Context.Remove(existigSA);
                await Context.SaveChangesAsync();
            }

            Context.StudentAssignments.Add(StudentAssignment);
            await Context.SaveChangesAsync();

            return RedirectToPage("/Classes/Index");
        }

        private bool SimulationExists(int id)
        {
            return Context.Simulations.Any(s => s.SimulationID == id);
        }
    }
}
