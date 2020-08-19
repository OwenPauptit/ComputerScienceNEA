using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NEA.Models;

namespace NEA.Pages.StudentAssignments
{
    public class EditModel : PageModel
    {
        private readonly NEA.Models.NEAContext _context;

        public EditModel(NEA.Models.NEAContext context)
        {
            _context = context;
        }

        [BindProperty]
        public StudentAssignment StudentAssignment { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StudentAssignment = await _context.StudentAssignments
                .Include(s => s.NEAUser)
                .Include(s => s.Simulation).FirstOrDefaultAsync(m => m.UserID == id);

            if (StudentAssignment == null)
            {
                return NotFound();
            }
           ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id");
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

            _context.Attach(StudentAssignment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentAssignmentExists(StudentAssignment.UserID))
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

        private bool StudentAssignmentExists(string id)
        {
            return _context.StudentAssignments.Any(e => e.UserID == id);
        }
    }
}
