using ChatApp.WepApi.Models.Identity;
using Microsoft.AspNetCore.Identity;

namespace ChatApp.WebApi
{
    public static class ApplicationDataInitializer
    {
        public static void SeedUsers(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            if (roleManager.FindByNameAsync("administrator").Result == null)
            {
                var applicationRole = new ApplicationRole() { Name = "administrator", NormalizedName = "ADMINISTRATOR" };
                var idResult = roleManager.CreateAsync(applicationRole).Result;
            }

            if (userManager.FindByEmailAsync("administrator@gmail.com").Result == null)
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = "administrator",
                    Email = "administrator@gmail.com"
                };

                IdentityResult result = userManager.CreateAsync(user, "qaz@123").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "administrator").Wait();
                }
            }
        }
    }
}
