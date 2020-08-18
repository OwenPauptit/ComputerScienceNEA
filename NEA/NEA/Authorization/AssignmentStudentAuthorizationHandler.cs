using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;
using NEA.Areas.Identity.Data;
using NEA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NEA.Authorization
{
    public class AssignmentStudentAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, StudentAssignment>
    {
        UserManager<NEAUser> _userManager;

        public AssignmentStudentAuthorizationHandler(UserManager<NEAUser>
            userManager)
        {
            _userManager = userManager;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                   OperationAuthorizationRequirement requirement,
                                   StudentAssignment resource)
        {
            if (context.User == null || resource == null)
            {
                return Task.CompletedTask;
            }

            // If not asking to enroll, unenroll or complete an assignment, return.
            if (requirement.Name != Constants.CompleteAssignmentOperationName)
            {
                return Task.CompletedTask;
            }

            // Students can enroll, unenroll and complete assignments
            if (context.User.IsInRole(Constants.StudentRole) && 
                resource.UserID == _userManager.GetUserId(context.User))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;


        }


    }
}
