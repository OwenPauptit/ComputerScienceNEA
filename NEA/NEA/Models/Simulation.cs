using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NEA.Models
{
    public class Simulation
    {

        public int SimulationID { get; set; }

        [Required]
        public string Name { get; set; }

    }
}
