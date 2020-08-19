using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NEA.Models;

namespace NEA.Pages.Assignments
{
    public class DetailsModel : PageModel
    {
        private readonly NEA.Models.NEAContext _context;

        public DetailsModel(NEA.Models.NEAContext context)
        {
            _context = context;
        }

        public ClassAssignment ClassAssignment { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ClassAssignment = await _context.ClassAssignments
                .Include(c => c.Classroom)
                .Include(c => c.Simulation).FirstOrDefaultAsync(m => m.ClassroomID == id);

            if (ClassAssignment == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
