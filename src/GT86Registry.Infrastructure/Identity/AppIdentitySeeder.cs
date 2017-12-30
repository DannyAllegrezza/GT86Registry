using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace GT86Registry.Infrastructure.Identity
{
    public class AppIdentitySeeder
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var defaultUser = new ApplicationUser
                {
                    UserName = "test-brz",
                    Email = "testuser@gt86registry.com",
                    FirstName = "Danny",
                    LastName = "Allegrezza",
                    City = "Cary",
                    State = "North Carolina",
                    PostalCode = "27560",
                    Country = "USA",
                    InstagramUri = "https://www.instagram.com/dude_danny/"
                };

                await userManager.CreateAsync(defaultUser, "J09TxRgIdKNi!");

                var defaultFrsUser = new ApplicationUser
                {
                    UserName = "test-frs",
                    Email = "testfrs@gt86registry.com",
                    FirstName = "John",
                    LastName = "Appleseed",
                    City = "Greensboro",
                    State = "North Carolina",
                    PostalCode = "27409",
                    Country = "USA",
                    InstagramUri = "https://www.instagram.com/dude_danny/"
                };

                await userManager.CreateAsync(defaultFrsUser, "J09TxRgIdKNi1!");

                var defaultGt86User = new ApplicationUser
                {
                    UserName = "test-gt86",
                    Email = "testgt86@gt86registry.com",
                    FirstName = "Bill",
                    LastName = "Doe",
                    City = "Cary",
                    State = "North Carolina",
                    PostalCode = "27560",
                    Country = "USA",
                    InstagramUri = "https://www.instagram.com/dude_danny/"
                };

                await userManager.CreateAsync(defaultGt86User, "J09TxRgIdKNi2!");
            }
        }
    }
}