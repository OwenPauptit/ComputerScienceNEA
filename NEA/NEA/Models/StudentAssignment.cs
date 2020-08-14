using NEA.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NEA.Models
{
    public class StudentAssignment
    {
        public string StudentID { get; set; }
        public int SimulationID { get; set; }

        [Range(0,100)]
        public int? Percentage { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateCompleted { get; set; }


        public NEAUser Student { get; set; }
        public Simulation Simulation { get; set; }

    }
}
