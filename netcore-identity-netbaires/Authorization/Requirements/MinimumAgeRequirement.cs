using Microsoft.AspNetCore.Authorization;
namespace netcore_identity_netbaires.Authorization.Requirements
{
    public class MinimumAgeRequirement : IAuthorizationRequirement
    {
        public int MinimumAge { get; private set; }

        public MinimumAgeRequirement(int minimumAge)
        {
            MinimumAge = minimumAge;
        }
    }
}
