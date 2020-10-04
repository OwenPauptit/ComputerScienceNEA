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
    public class StudentQuestionStudentAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, StudentQuestion>
    {
        UserManager<NEAUser> _userManager;

        public StudentQuestionStudentAuthorizationHandler(UserManager<NEAUser>
            userManager)
        {
            _userManager = userManager;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                   OperationAuthorizationRequirement requirement,
                                   StudentQuestion resource)
        {
            if (context.User == null || resource == null)
            {
                return Task.CompletedTask;
            }



            // If not asking to view questions, return 
            if (requirement.Name != Constants.ViewStudentAssignmentOperationName &&
                requirement.Name != Constants.CreateStudentAssignmentOperationName)
            {
                return Task.CompletedTask;
            }

            if (context.User.IsInRole(Constants.StudentRole) && resource.UserID == _userManager.GetUserId(context.User))
            {
                context.Succeed(requirement);
            }


            return Task.CompletedTask;


        }
    
    }
}
