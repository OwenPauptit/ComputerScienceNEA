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
    public class IndexModel : PageModel
    {
        private readonly NEA.Models.NEAContext _context;

        public IndexModel(NEA.Models.NEAContext context)
        {
            _context = context;
        }

        public IList<ClassAssignment> ClassAssignment { get;set; }

        public async Task OnGetAsync()
        {
            ClassAssignment = await _context.ClassAssignments
                .Include(c => c.Classroom)
                .Include(c => c.Simulation).ToListAsync();
        }
    }
}
