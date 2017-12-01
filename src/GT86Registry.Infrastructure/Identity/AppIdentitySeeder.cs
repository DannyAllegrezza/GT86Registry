using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace GT86Registry.Infrastructure.Identity
{
    public class AppIdentitySeeder
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager)
        {
            var defaultUser = new ApplicationUser
            {
                UserName = "testuser@gt86registry.com",
                Email = "testuser@gt86registry.com",
                FirstName = "Danny",
                LastName = "Allegrezza",
                City = "Cary",
                State = "North Carolina",
                PostalCode = "27560",
                Country = "USA",
                InstagramUri = "https://www.instagram.com/dude_danny/"
            };

            await userManager.CreateAsync(defaultUser, "J09TxRgIdKNi");
        }
    }
}