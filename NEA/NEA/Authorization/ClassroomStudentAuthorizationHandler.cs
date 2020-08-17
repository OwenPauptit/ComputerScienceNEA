﻿using Microsoft.AspNetCore.Authorization;
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
    public class StudentAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, Classroom>
    {
        UserManager<NEAUser> _userManager;

        public StudentAuthorizationHandler(UserManager<NEAUser>
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

            // If not asking to enroll, unenroll or complete an assignment, return.
            if (requirement.Name != Constants.EnrollOperationName &&
                requirement.Name != Constants.UnenrollOperationName &&
                requirement.Name != Constants.CompleteAssignmentOperationName)
            {
                return Task.CompletedTask;
            }

            // Students can enroll, unenroll and complete assignments
            if (context.User.IsInRole(Constants.StudentRole))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;


        }


    }
}
