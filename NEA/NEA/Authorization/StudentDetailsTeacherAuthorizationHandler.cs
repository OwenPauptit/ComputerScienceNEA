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
    public class StudentDetailsTeacherAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, Enrollment>
    {
        UserManager<NEAUser> _userManager;

        public StudentDetailsTeacherAuthorizationHandler(UserManager<NEAUser>
            userManager)
        {
            _userManager = userManager;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                   OperationAuthorizationRequirement requirement,
                                   Enrollment resource)
        {
            if (context.User == null || resource == null)
            {
                return Task.CompletedTask;
            }



            // If not asking to view questions, return 
            if (requirement.Name != Constants.ViewStudentAssignmentOperationName)
            {
                return Task.CompletedTask;
            }

            // Teachers can view student assignments of students who are in their classroom
            if (context.User.IsInRole(Constants.TeacherRole) &&
                resource.Classroom.Teacher.Id == _userManager.GetUserId(context.User))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }

        }
    }
