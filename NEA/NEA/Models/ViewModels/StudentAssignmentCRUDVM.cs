using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NEA.Models.ViewModels
{
    public class StudentAssignmentCRUDVM
    {
        [Range(0,100)]
        public int Percentage { get; set; }
    }
}
