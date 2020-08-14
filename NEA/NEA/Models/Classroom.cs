using NEA.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace NEA.Models
{
    public class Classroom
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ClassroomID { get; set; }

        [Required]
        [ForeignKey("Teacher")]
        [AllowNull]
        public string UserID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [AllowNull]
        public NEAUser Teacher { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
