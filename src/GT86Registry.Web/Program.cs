using GT86Registry.Infrastructure.Data;
using GT86Registry.Infrastructure.Identity;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace GT86Registry.Web
{
    public class Program
    {
        public static IConfigurationRoot Configuration { get; set; }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();

        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);

            var builder = new ConfigurationBuilder();
            Configuration = builder.Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                var config = services.GetRequiredService<IConfiguration>();
                try
                {
                    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                    var adminPw = config["SeedAdminPW"];
                    AppIdentitySeeder.SeedAsync(userManager, roleManager, adminPw).Wait();

                    var vehicleContext = services.GetRequiredService<VehicleDbContext>();
                    VehicleSeeder.SeedAsync(vehicleContext, userManager, loggerFactory)
                        .Wait();
                }
                catch (Exception ex)
                {
                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(ex, "An error occurred seeding the DB.");
                }
            }
            HibernatingRhinos.Profiler.Appender.EntityFramework.EntityFrameworkProfiler.Initialize();

            host.Run();
        }
    }
}