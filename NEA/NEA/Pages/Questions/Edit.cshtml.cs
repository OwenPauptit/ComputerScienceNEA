using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NEA.Models;

namespace NEA.Pages.Questions
{
    public class EditModel : PageModel
    {
        private readonly NEA.Models.NEAContext _context;

        public EditModel(NEA.Models.NEAContext context)
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
           ViewData["SimulationID"] = new SelectList(_context.Questions, "SimulationID", "AnswerString");
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

            _context.Attach(StudentQuestion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentQuestionExists(StudentQuestion.SimulationID))
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

        private bool StudentQuestionExists(int id)
        {
            return _context.StudentQuestions.Any(e => e.SimulationID == id);
        }
    }
}
