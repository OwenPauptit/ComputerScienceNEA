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
    public class TeacherAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, Classroom>
    {
        UserManager<NEAUser> _userManager;

        public TeacherAuthorizationHandler(UserManager<NEAUser>
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

            

            // If not asking for CRUD (except read) permissions for a class or assignment, return 
            if (requirement.Name != Constants.CreateClassOperationName &&
                requirement.Name != Constants.EditClassOperationName &&
                requirement.Name != Constants.DeleteClassOperationName &&
                
                requirement.Name != Constants.CreateAssignmentOperationName &&
                requirement.Name != Constants.EditAssignmentOperationName &&
                requirement.Name != Constants.DeleteAssignmentOperationName)
            {
                return Task.CompletedTask;
            }

            // Teachers can perform crud operations on classes and assignments
            if (context.User.IsInRole(Constants.TeacherRole) && resource.UserID == _userManager.GetUserId(context.User))
            {
                context.Succeed(requirement);
            }    
            
            return Task.CompletedTask;


        }
    }
}
