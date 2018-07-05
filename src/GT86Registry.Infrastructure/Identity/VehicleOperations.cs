using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace GT86Registry.Infrastructure.Identity
{
    public static class VehicleOperations
    {
        public static OperationAuthorizationRequirement Create =
          new OperationAuthorizationRequirement { Name = CreateOperationName };
        public static OperationAuthorizationRequirement Read =
          new OperationAuthorizationRequirement { Name = ReadOperationName };
        public static OperationAuthorizationRequirement Update =
          new OperationAuthorizationRequirement { Name = UpdateOperationName };
        public static OperationAuthorizationRequirement Delete =
          new OperationAuthorizationRequirement { Name = DeleteOperationName };
        public static OperationAuthorizationRequirement Approve =
          new OperationAuthorizationRequirement { Name = ApproveOperationName };
        public static OperationAuthorizationRequirement Reject =
          new OperationAuthorizationRequirement { Name = RejectOperationName };

        public static readonly string CreateOperationName = "Create";
        public static readonly string ReadOperationName = "Read";
        public static readonly string UpdateOperationName = "Update";
        public static readonly string DeleteOperationName = "Delete";
        public static readonly string ApproveOperationName = "Approve";
        public static readonly string RejectOperationName = "Reject";
    }
}
