using NEA.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NEA.Models
{
    public class Enrollment
    {
        

        public string StudentID { get; set; }
        
        [ForeignKey("Classroom")]
        [StringLength(10, MinimumLength = 6)]
        public string ClassID { get; set; }

        public NEAUser Student { get; set; }
        public Classroom Classroom { get; set; }

        //Need to use FluentAPI for composite key
    }
}
