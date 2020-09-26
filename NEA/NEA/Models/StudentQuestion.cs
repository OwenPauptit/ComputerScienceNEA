using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NEA.Areas.Identity.Data;

namespace NEA.Models
{
    public class StudentQuestion
    {
        [Required]
        public int SimulationID { get; set; }

        [Required]
        public int QIndex { get; set; }

        [Required]
        [ForeignKey("NEAUser")]
        public string UserID { get; set; }

        public string Answer { get; set; }

        [Required]
        public bool Correct { get; set; }

        public Simulation Simulation { get; set; }

        public Question Question { get; set; }
        public NEAUser NEAUser { get; set; }
    }
}
