using Madhuu_PMS.Web.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace Madhuu_PMS.Web.Data
{
    public static class SeedingData
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            // Ensure roles exist
            string[] roleNames = { "ADMIN", "USER" };
            foreach (var roleName in roleNames)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            // Ensure admin user exists
            if (await userManager.FindByEmailAsync("admin@gmail.com") == null)
            {
                var adminUser = new ApplicationUser
                {
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com",
                    FirstName = "Product",
                    LastName = "Admin",
                    IsActive = true,
                    PhoneNumber = "9862150120",
                    Address = "Kathmandu",
                    CreatedBy = "admin",
                    CreatedDate = DateTime.Now
                };

                var result = await userManager.CreateAsync(adminUser, "A@dmin1");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "ADMIN");
                }
            }
        }
    }
}
