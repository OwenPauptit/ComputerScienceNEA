using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NEA.Models;

namespace NEA.Pages.Assignments
{
    public class EditModel : PageModel
    {
        private readonly NEA.Models.NEAContext _context;

        public EditModel(NEA.Models.NEAContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["ClassroomID"] = new SelectList(_context.Classrooms, "ClassroomID", "ClassroomID");
           ViewData["SimulationID"] = new SelectList(_context.Simulations, "SimulationID", "Name");
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

            _context.Attach(ClassAssignment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassAssignmentExists(ClassAssignment.ClassroomID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ClassAssignmentExists(string id)
        {
            return _context.ClassAssignments.Any(e => e.ClassroomID == id);
        }
    }
}
