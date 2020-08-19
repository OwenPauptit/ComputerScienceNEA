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

namespace NEA.Pages.Assignments
{
    public class EditModel : SimulationNamePageModel
    {
        public EditModel(
        NEAContext context,
        IAuthorizationService authorizationService,
        UserManager<NEAUser> userManager)
        : base(context, authorizationService, userManager)
        {
        }


        [BindProperty]
        public ClassAssignment ClassAssignment { get; set; }

        public async Task<IActionResult> OnGetAsync(string classId, int? simID, string dateDue)
        {
            if (classId == null || simID == null)
            {
                return NotFound();
            }

            if (dateDue != null)
            {
                return await EditAssignment();

            }

            ClassAssignment = await Context.ClassAssignments
                .Include(c => c.Classroom)
                .Include(c => c.Simulation)
                .Where(m => m.ClassroomID == classId)
                .SingleOrDefaultAsync(m => m.SimulationID == simID);

            if (ClassAssignment == null)
            {
                return NotFound();
            }

            return Page();
        }

        private async Task<IActionResult> EditAssignment()
        {
            if (ClassAssignment == null)
            {
                return NotFound();
            }

            var isAuthorized = await AuthorizationService.AuthorizeAsync(User, ClassAssignment, Operations.EditAssignment);
            if(!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            ClassAssignment.DateSet = DateTime.Now;

            Context.Attach(ClassAssignment).State = EntityState.Modified;

            try
            {
                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassAssignmentExists(ClassAssignment.ClassroomID, ClassAssignment.SimulationID))
                {
                    return base.NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("/Classes/Index");
        }


        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string classID)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            return await EditAssignment();
            
        }

        private bool ClassAssignmentExists(string classId, int simId)
        {
            return Context.ClassAssignments
                .Where(e => e.SimulationID == simId)
                .Any(e => e.ClassroomID == classId);
        }
    }
}
