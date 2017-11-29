using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GT86Registry.Web.Services;
using GT86Registry.Infrastructure.Identity;
using GT86Registry.Infrastructure.Data;

namespace GT86Registry.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();

            // Setup CarRegistry database connection, inject in options to CarDbContext
            services.AddDbContext<VehicleDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("CarRegistryConnection")));

            // Setup Identity database connection and register Identity service
            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("IdentityConnection")));


            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddTransient<VehicleSeeder>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();

                // Seed the database
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var vehicleSeeder = scope.ServiceProvider.GetService<VehicleSeeder>();
                    vehicleSeeder.SeedAsync().Wait();
                }
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
