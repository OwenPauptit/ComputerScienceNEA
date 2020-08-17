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

namespace NEA.Pages.Classes
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
    }
}
