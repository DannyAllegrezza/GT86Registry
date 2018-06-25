using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GT86Registry.Infrastructure.Identity
{
    /// <summary>
    /// Helper class used to create and seed Identity users.
    /// </summary>
    public class AppIdentitySeeder
    {
        private const string _testUserPw = "TestUser123!";
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, string adminPW)
        {
            if (!userManager.Users.Any())
            {
                var adminAppUser = new ApplicationUser()
                {
                    UserName = "admin",
                    Email = SeedData.ADMIN_EMAIL,
                    FirstName = "Administrator",
                    City = "Cary",
                    State = "North Carolina",
                    PostalCode = "27560",
                    Country = "USA",
                    InstagramUri = SeedData.ADMIN_INSTAGRAM
                };

                var adminId = await EnsureUserAsync(userManager, roleManager, adminPW, adminAppUser);
                await EnsureRoleAsync(userManager, roleManager, adminId, ApplicationRoles.AdministratorRole);

                var defaultUser = new ApplicationUser
                {
                    UserName = "test-brz",
                    Email = SeedData.USER_EMAIL_BRZ,
                    FirstName = "Danny",
                    LastName = "Allegrezza",
                    City = "Cary",
                    State = "North Carolina",
                    PostalCode = "27560",
                    Country = "USA",
                    InstagramUri = "https://www.instagram.com/dude_danny/"
                };

                var defaultUserId = await EnsureUserAsync(userManager, roleManager, _testUserPw, defaultUser);
                await EnsureRoleAsync(userManager, roleManager, defaultUserId, ApplicationRoles.ModeratorRole);

                var defaultFrsUser = new ApplicationUser
                {
                    UserName = "test-frs",
                    Email = SeedData.USER_EMAIL_FRS,
                    FirstName = "John",
                    LastName = "Appleseed",
                    City = "Greensboro",
                    State = "North Carolina",
                    PostalCode = "27409",
                    Country = "USA",
                    InstagramUri = "https://www.instagram.com/dude_danny/"
                };

                var defaultFrsUserId = await EnsureUserAsync(userManager, roleManager, _testUserPw, defaultFrsUser);
                await EnsureRoleAsync(userManager, roleManager, defaultFrsUserId, ApplicationRoles.MemberRole);


                var defaultGt86User = new ApplicationUser
                {
                    UserName = "test-gt86",
                    Email = SeedData.USER_EMAIL_GT86,
                    FirstName = "Bill",
                    LastName = "Doe",
                    City = "Cary",
                    State = "North Carolina",
                    PostalCode = "27560",
                    Country = "USA",
                    InstagramUri = "https://www.instagram.com/dude_danny/"
                };

                var defaultGt86UserId = await EnsureUserAsync(userManager, roleManager, _testUserPw, defaultGt86User);
                await EnsureRoleAsync(userManager, roleManager, defaultGt86UserId, ApplicationRoles.MemberRole);
            }
        }

        public static async Task<IdentityResult> EnsureRoleAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, string userId, string role)
        {
            IdentityResult roleResult = null;

            if (!await roleManager.RoleExistsAsync(role))
            {
                roleResult = await roleManager.CreateAsync(new IdentityRole(role));
            }

            var user = await userManager.FindByIdAsync(userId);

            roleResult = await userManager.AddToRoleAsync(user, role);

            return roleResult;
        }

        private static async Task<string> EnsureUserAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, string password, ApplicationUser appUser)
        {
            IdentityResult userResult = null;

            var user = await userManager.FindByNameAsync(appUser.UserName);
            if (user == null)
            {
                userResult = await userManager.CreateAsync(appUser, password);
                if (!userResult.Succeeded)
                {
                    throw new Exception(userResult.Errors.ToString());
                }
            }


            return appUser.Id;
        }
    }
}