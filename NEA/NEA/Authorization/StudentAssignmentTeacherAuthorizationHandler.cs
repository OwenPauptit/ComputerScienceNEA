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
    public class StudentAssignmentTeacherAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, StudentAssignment>
    {
        UserManager<NEAUser> _userManager;

        public StudentAssignmentTeacherAuthorizationHandler(UserManager<NEAUser>
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



            // If not asking to view questions, return 
            if (requirement.Name != Constants.ViewStudentAssignmentOperationName &&
                requirement.Name != Constants.OverrideStudentAssignmentOperationName)
            {
                return Task.CompletedTask;
            }

            // Teachers can view student assignments of students who are in their classroom
            if (context.User.IsInRole(Constants.TeacherRole) && 
                resource.NEAUser.Enrollments
                    .SingleOrDefault(e => e.Classroom.Teacher.Id == _userManager.GetUserId(context.User)) != null)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;


        }
    }
}
