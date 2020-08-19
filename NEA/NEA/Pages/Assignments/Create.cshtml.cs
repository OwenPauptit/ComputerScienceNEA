using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.EntityFrameworkCore;
using NEA.Areas.Identity.Data;
using NEA.Authorization;
using NEA.Models;
using NEA.Models.ViewModels;

namespace NEA.Pages.Assignments
{
    public class CreateModel : SimulationNamePageModel
    {
        public CreateModel(
        NEAContext context,
        IAuthorizationService authorizationService,
        UserManager<NEAUser> userManager)
        : base(context, authorizationService, userManager)
        {
        }

        public IActionResult OnGet(string classID)
        {
            if (String.IsNullOrEmpty(classID))
            {
                return NotFound();
            }


            if (Context.Classrooms
                .Include(c => c.ClassAssignments)
                .SingleOrDefault(c => c.ClassroomID == classID) == null)
            {
                return NotFound();
            }

            PopulateSimulationsDropDownList();
            return Page();
        }


        [BindProperty]
        public ClassAssignmentVM ClassAssignmentVM { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string classID)
        {
            if (classID == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                PopulateSimulationsDropDownList(ClassAssignmentVM?.SimulationID);
                return Page();
            }

            List<int> simIds = await (from s in Context.Simulations
                                select s.SimulationID)
                                .ToListAsync();

            if (!simIds.Contains(ClassAssignmentVM.SimulationID))
            {
                PopulateSimulationsDropDownList();
                return Page();
            }

            if (Context.ClassAssignments
                .Where(c => c.ClassroomID == classID)
                .SingleOrDefault(c => c.SimulationID == ClassAssignmentVM.SimulationID) != null)
            {
                return RedirectToPage("./Edit", classID, ClassAssignmentVM.SimulationID, ClassAssignmentVM.DateDue.Value.ToString());
            }


            var classAssignment = new ClassAssignment
            {
                ClassroomID = classID,
                SimulationID = ClassAssignmentVM.SimulationID,
                DateDue = ClassAssignmentVM.DateDue.Value,
                DateSet = DateTime.Now.Date
            };

            var isAuthorized = await AuthorizationService.AuthorizeAsync
                (User, classAssignment, Operations.CreateAssignment);
            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            Context.ClassAssignments.Add(classAssignment);
            await Context.SaveChangesAsync();

            return RedirectToPage("/Classes/Index");
        }
    }
}
