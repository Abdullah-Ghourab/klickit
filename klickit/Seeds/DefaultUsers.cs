using klickit.Core.Constants;
using Microsoft.AspNetCore.Identity;

namespace klickit.Seeds
{
    public class DefaultUsers
    {
        public static async Task SeedUsersAsync(UserManager<IdentityUser> UserManager)
        {
            IdentityUser Supplier = new()
            {
                UserName = "Supplier@Klickit.com",
                Email = "Supplier@Klickit.com",
                EmailConfirmed = true
            };
            IdentityUser Shopper = new()
            {
                UserName = "Shopper@Klickit.com",
                Email = "Shopper@Klickit.com",
                EmailConfirmed = true
            };
            await CreateUser(UserManager, Shopper, AppRoles.Shopper, "P@ssword123");
            await CreateUser(UserManager, Supplier, AppRoles.Supplier, "P@ssword123");
        }
        private static async Task CreateUser(UserManager<IdentityUser> UserManager, IdentityUser UserToCreate, string role, string password)
        {
            var User = await UserManager.FindByNameAsync(UserToCreate.UserName!);
            if (User is null)
            {
                await UserManager.CreateAsync(UserToCreate, password);
                await UserManager.AddToRoleAsync(UserToCreate, role);
            }
        }
    }
}
