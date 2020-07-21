using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AspNetMVC.Security
{
    public class CanAccessEmployeeRequirement : IAuthorizationRequirement
    {
    }

    public class CanAccessEmployeeHandler : AuthorizationHandler<CanAccessEmployeeRequirement, int>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
            CanAccessEmployeeRequirement requirement, int employeeId)
        {

            if (context.User.HasClaim("IsAdmin", "True")
                || context.User.HasClaim(ClaimTypes.NameIdentifier, employeeId.ToString()))
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}
