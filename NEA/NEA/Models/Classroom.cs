using NEA.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace NEA.Models
{
    public class Classroom
    {
        [Key]
        [Required]
        [StringLength(10,MinimumLength = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ClassID { get; set; }

        [Required]
        public string TeacherID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }


        public NEAUser Teacher { get; set; }
        public ICollection<NEAUser> Students { get; set; }
    }
}
