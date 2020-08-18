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
    public class ClassroomTeacherAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, Classroom>
    {
        UserManager<NEAUser> _userManager;

        public ClassroomTeacherAuthorizationHandler(UserManager<NEAUser>
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
                requirement.Name != Constants.DeleteClassOperationName)
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
