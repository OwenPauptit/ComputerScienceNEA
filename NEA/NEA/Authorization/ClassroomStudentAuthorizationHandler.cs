using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using NEA.Areas.Identity.Data;
using NEA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NEA.Authorization
{
    public class ClassroomStudentAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, Classroom>
    {
        UserManager<NEAUser> _userManager;

        public ClassroomStudentAuthorizationHandler(UserManager<NEAUser>
            userManager)
        {
            _userManager = userManager;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                   OperationAuthorizationRequirement requirement,
                                   Classroom resource)
        {
            if (context.User == null || resource == null)
            {
                return Task.CompletedTask;
            }

            var enrollment = new Enrollment
            {
                ClassroomID = resource.ClassroomID,
                NEAUserId = _userManager.GetUserId(context.User)
            };

            // Students can enroll and unenroll
            if (requirement.Name == Constants.EnrollOperationName &&
                context.User.IsInRole(Constants.StudentRole))
            {
                if (resource.Enrollments?.SingleOrDefault(e => e.NEAUserId == _userManager.GetUserId(context.User)) == null)
                {
                    context.Succeed(requirement);
                }
            }
            else if (requirement.Name == Constants.UnenrollOperationName &&
                context.User.IsInRole(Constants.StudentRole))
            {
                if (resource.Enrollments?.SingleOrDefault(e => e.NEAUserId == _userManager.GetUserId(context.User)) != null)
                {
                    context.Succeed(requirement);
                }
            }

            return Task.CompletedTask;


        }


    }
}
