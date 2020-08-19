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
    public class AssignmentTeacherAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, ClassAssignment>
    {
        UserManager<NEAUser> _userManager;

        public AssignmentTeacherAuthorizationHandler(UserManager<NEAUser>
            userManager)
        {
            _userManager = userManager;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                   OperationAuthorizationRequirement requirement,
                                   ClassAssignment resource)
        {
            if (context.User == null || resource == null)
            {
                return Task.CompletedTask;
            }



            // If not asking for CRUD (except read) permissions for a class or assignment, return 
            if (requirement.Name != Constants.CreateAssignmentOperationName &&
                requirement.Name != Constants.EditAssignmentOperationName &&
                requirement.Name != Constants.DeleteAssignmentOperationName)
            {
                return Task.CompletedTask;
            }

            // Teachers can perform crud operations on classes and assignments
            if (context.User.IsInRole(Constants.TeacherRole))
            {
                if (resource.Classroom == null)
                {
                    context.Succeed(requirement);
                }
                else if (resource.Classroom.UserID == _userManager.GetUserId(context.User))
                {
                    context.Succeed(requirement);

                }
            }

            return Task.CompletedTask;


        }
    }
}
