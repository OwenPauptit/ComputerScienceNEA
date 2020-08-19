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

namespace NEA.Pages.Assignments
{
    public class DetailsModel : SimulationNamePageModel
    {
        public DetailsModel(
        NEAContext context,
        IAuthorizationService authorizationService,
        UserManager<NEAUser> userManager)
        : base(context, authorizationService, userManager)
        {
        }

        public ClassAssignment ClassAssignment { get; set; }

        public async Task<IActionResult> OnGetAsync(string classId, int simId)
        {
            if (classId == null)
            {
                return NotFound();
            }

            ClassAssignment = await Context.ClassAssignments
                .Include(c => c.Classroom)
                .Include(c => c.Simulation)
                .SingleOrDefaultAsync(m => m.ClassroomID == classId && m.SimulationID == simId);

            if (ClassAssignment == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
