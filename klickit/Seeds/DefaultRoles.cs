using klickit.Core.Constants;
using Microsoft.AspNetCore.Identity;

namespace klickit.Seeds
{
    public class DefaultRoles
    {
        public static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.Roles.Any())
            {
                await roleManager.CreateAsync(new IdentityRole(AppRoles.Supplier));
                await roleManager.CreateAsync(new IdentityRole(AppRoles.Shopper));
            }
        }
    }
}
