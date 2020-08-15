using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using NEA.Models;

namespace NEA.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the NEAUser class
    public class NEAUser : IdentityUser
    {
        [PersonalData]
        public string FirstName { get; set; }

        [PersonalData]
        public string LastName { get; set; }

        public ICollection<StudentAssignment> StudentAssignments { get; set; }
    }
}
