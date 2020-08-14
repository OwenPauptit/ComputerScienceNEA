using Microsoft.VisualStudio.Web.CodeGeneration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NEA.Models
{
    public class ClassAssignment
    {
        
        public string ClassroomID { get; set; }
        public int SimulationID { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateSet { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateDue { get; set; }
        public Classroom Classroom { get; set; }
        public Simulation Simulation { get; set; }
    }
}
