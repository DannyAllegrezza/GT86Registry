using GT86Registry.Core.Entities;
using GT86Registry.Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using System.Threading.Tasks;

namespace GT86Registry.Web.Authorization
{
    public class VehicleAdministratorsAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, Vehicle>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OperationAuthorizationRequirement requirement, Vehicle resource)
        {
            if (context.User == null) { return Task.CompletedTask; }

            // Admins can do anything
            if (context.User.IsInRole(ApplicationRoles.AdministratorRole))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}