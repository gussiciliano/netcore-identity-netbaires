using Microsoft.AspNetCore.Authorization;
using netcore_identity_netbaires.Authorization.Requirements;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
namespace netcore_identity_netbaires.Authorization.Handlers
{
    public class MinimumAgeHandler : AuthorizationHandler<MinimumAgeRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                                        MinimumAgeRequirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type == ClaimTypes.DateOfBirth))
            {
                return Task.CompletedTask;
            }
            var dateOfBirth = Convert.ToDateTime(
                context.User.FindFirst(c => c.Type == ClaimTypes.DateOfBirth).Value);
            int calculatedAge = DateTime.Today.Year - dateOfBirth.Year;
            if (dateOfBirth > DateTime.Today.AddYears(-calculatedAge))
                calculatedAge--;
            if (calculatedAge >= requirement.MinimumAge)
                context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }
}
