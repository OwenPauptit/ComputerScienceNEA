using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NEA.Models;

namespace NEA.Pages.Questions
{
    public class DeleteModel : PageModel
    {
        private readonly NEA.Models.NEAContext _context;

        public DeleteModel(NEA.Models.NEAContext context)
        {
            _context = context;
        }

        [BindProperty]
        public StudentQuestion StudentQuestion { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StudentQuestion = await _context.StudentQuestions
                .Include(s => s.Question)
                .Include(s => s.Simulation).FirstOrDefaultAsync(m => m.SimulationID == id);

            if (StudentQuestion == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StudentQuestion = await _context.StudentQuestions.FindAsync(id);

            if (StudentQuestion != null)
            {
                _context.StudentQuestions.Remove(StudentQuestion);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
