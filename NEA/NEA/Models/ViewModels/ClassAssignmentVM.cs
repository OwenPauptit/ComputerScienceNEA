using NEA.CustomAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NEA.Models.ViewModels
{
    public class ClassAssignmentVM
    {

        public string ClassName { get; set; }

        [Display(Name = "Simulation")]
        public int SimulationID { get; set; }

        [FutureDate(ErrorMessage = "Due date must be in the future")]
        [DataType(DataType.Date)]
        [Display(Name = "Date Due")]
        public DateTime? DateDue { get; set; }


    }
}
