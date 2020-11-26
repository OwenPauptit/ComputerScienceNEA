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

namespace NEA.Pages
{
    [AllowAnonymous]
    public class SimulationsModel : DI_BasePageModel
    {
        public SimulationsModel(
        NEAContext context,
        IAuthorizationService authorizationService,
        UserManager<NEAUser> userManager)
        : base(context, authorizationService, userManager)
        {
        }
        public Simulation SelectedSimulation { get; set; }
        public IList<Simulation> Simulations { get; set; }
        public async Task OnGet(int? id)
        {
            Simulations = await (from s in Context.Simulations
                                 orderby s.Name
                                 select s)
                                 .AsNoTracking()
                                 .ToListAsync();

            if (id != null)
            {
                SelectedSimulation = Simulations
                    .Where(s => s.SimulationID == id)
                    .SingleOrDefault();
            }
        }
    }
}