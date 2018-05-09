using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using netcore_identity_netbaires.Models;

namespace netcore_identity_netbaires.Authorization.Roles
{
    public static class MyIdentityDataInitializer
    {
        public static void SeedData(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager, configuration["AdminUser:Username"], configuration["AdminUser:Password"]);
        }

        public static void SeedUsers(UserManager<ApplicationUser> userManager, string username, string password)
        {
            if (userManager.FindByNameAsync("admin").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = username;
                user.Email = username;
                user.DateOfBirth = new DateTime(1960, 1, 1);
                IdentityResult result = userManager.CreateAsync(user, password).Result;
                if (result.Succeeded)
                    userManager.AddToRoleAsync(user, "Administrator").Wait();
            }
        }

        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("NormalUser").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "NormalUser";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }


            if (!roleManager.RoleExistsAsync("Administrator").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Administrator";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }
        }
    }
}
