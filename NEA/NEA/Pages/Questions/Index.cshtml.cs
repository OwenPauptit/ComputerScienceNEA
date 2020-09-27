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
    public class IndexModel : PageModel
    {
        private readonly NEA.Models.NEAContext _context;

        public IndexModel(NEA.Models.NEAContext context)
        {
            _context = context;
        }

        public IList<StudentQuestion> StudentQuestion { get;set; }

        public async Task OnGetAsync()
        {
            StudentQuestion = await _context.StudentQuestions
                .Include(s => s.Question)
                .Include(s => s.Simulation).ToListAsync();
        }
    }
}
