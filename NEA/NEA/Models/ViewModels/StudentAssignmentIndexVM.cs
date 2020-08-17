using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NEA.Models.ViewModels
{
    public class StudentAssignmentIndexVM
    {
        //public string ClassroomID { get; set; }
        //public string StudentID { get; set; }
        public string StudentName { get; set; }

        public int? Percentage { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateCompleted { get; set; }

        public int SimulationID { get; set; }
    }
}
