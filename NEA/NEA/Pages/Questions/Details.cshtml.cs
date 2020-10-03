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

namespace NEA.Pages.Questions
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

        public List<StudentQuestion> StudentQuestions { get; set; }

        public StudentAssignment StudentAssignment { get; set; }

        public async Task<IActionResult> OnGet(int? simID)
        {

            if (simID == null)
            {
                return NotFound();
            }

            StudentQuestions = await Context.StudentQuestions
                .Include(q => q.Simulation)
                .Include(q => q.Question)
                .Where(q => q.SimulationID == simID
                    && q.UserID == UserManager.GetUserId(User))
                .ToListAsync();

            StudentAssignment = Context.StudentAssignments
                .SingleOrDefault(a => a.UserID == UserManager.GetUserId(User) 
                                    && a.SimulationID == simID);
                

            if (StudentQuestions == null || StudentQuestions.Count() == 0 || StudentAssignment == null)
            {
                return NotFound();
            }


            var isAuthorized = await AuthorizationService.AuthorizeAsync(User, StudentAssignment, Operations.ViewStudentAssignment);

            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            return Page();
        }
    }
}
