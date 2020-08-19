using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NEA.Areas.Identity.Data;
using NEA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NEA.Pages.Assignments
{
    public class SimulationNamePageModel : DI_BasePageModel
    {
        
        public SimulationNamePageModel(
        NEAContext context,
        IAuthorizationService authorizationService,
        UserManager<NEAUser> userManager)
        : base(context, authorizationService, userManager)
        {
        }

        public SelectList SimulationNamesSL { get; set; }

        public void PopulateSimulationsDropDownList(object selectedSimulation = null)
        {
            var simQuery = from s in Context.Simulations
                                   orderby s.Name // Sort by name.
                                   select s;

            SimulationNamesSL = new SelectList(simQuery.AsNoTracking(),
                        "SimulationID", "Name", selectedSimulation);
        }



    }
}
