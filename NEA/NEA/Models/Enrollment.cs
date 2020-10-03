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
        [ForeignKey("NEAUser")]
        public string NEAUserId { get; set; }
     
        public string ClassroomID { get; set; }

        public NEAUser NEAUser { get; set; }
        public Classroom Classroom { get; set; }

        //Need to use FluentAPI for composite key
    }
}
