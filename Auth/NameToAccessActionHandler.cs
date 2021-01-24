using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Auth
{
    public class NameToAccessActionHandler : AuthorizationHandler<NameRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                                       NameRequirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type == ClaimTypes.Name))
            {
                
                return Task.CompletedTask;
            }
            
            var name = context.User.FindFirst(c => c.Type == ClaimTypes.Name
                                           ).Value;
            if (name == requirement.NameToAccessAction)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }

}
