using Microsoft.AspNetCore.Authorization.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NEA.Authorization
{

    public class Operations
    {
        public static OperationAuthorizationRequirement Enroll =
            new OperationAuthorizationRequirement { Name = Constants.EnrollOperationName };
        public static OperationAuthorizationRequirement Unenroll =
            new OperationAuthorizationRequirement { Name = Constants.UnenrollOperationName };

        public static OperationAuthorizationRequirement CreateClass =
            new OperationAuthorizationRequirement { Name = Constants.CreateClassOperationName };
        public static OperationAuthorizationRequirement EditClass =
            new OperationAuthorizationRequirement { Name = Constants.EditClassOperationName };
        public static OperationAuthorizationRequirement DeleteClass =
            new OperationAuthorizationRequirement { Name = Constants.DeleteClassOperationName };

        public static OperationAuthorizationRequirement CreateAssignment =
            new OperationAuthorizationRequirement { Name = Constants.CreateAssignmentOperationName };
        public static OperationAuthorizationRequirement EditAssignment =
            new OperationAuthorizationRequirement { Name = Constants.EditAssignmentOperationName };
        public static OperationAuthorizationRequirement DeleteAssignment =
            new OperationAuthorizationRequirement { Name = Constants.DeleteAssignmentOperationName };
        public static OperationAuthorizationRequirement CompleteAssignment =
            new OperationAuthorizationRequirement { Name = Constants.CompleteAssignmentOperationName };
    }

    public class Constants
    {

        public static readonly string StudentRole = "Student";
        public static readonly string TeacherRole = "Teacher";

        public static readonly string EnrollOperationName = "Enroll";
        public static readonly string UnenrollOperationName = "Unenroll";

        public static readonly string CreateClassOperationName = "CreateClass";
        public static readonly string EditClassOperationName = "EditClass";
        public static readonly string DeleteClassOperationName = "DeleteClass";

        public static readonly string CreateAssignmentOperationName = "CreateAssignment";
        public static readonly string EditAssignmentOperationName = "EditAssignment";
        public static readonly string DeleteAssignmentOperationName = "DeleteAssignment";
        public static readonly string CompleteAssignmentOperationName = "CompleteAssignment";
    }
}
