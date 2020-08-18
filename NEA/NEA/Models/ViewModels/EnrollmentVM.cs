using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NEA.Models.ViewModels
{
    public class EnrollmentVM
    {
        [Display(Name = "Classroom Code")]
        public string ClassroomID { get; set; }
    }
}
