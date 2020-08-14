using NEA.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NEA.Models
{
    public class StudentAssignment
    {
        [ForeignKey("NEAUser")]
        public string UserID { get; set; }
        public int SimulationID { get; set; }

        [Range(0,100)]
        public int? Percentage { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateCompleted { get; set; }


        public NEAUser NEAUser { get; set; }
        public Simulation Simulation { get; set; }

    }
}
