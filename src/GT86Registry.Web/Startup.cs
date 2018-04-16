using GT86Registry.Core.Factories;
using GT86Registry.Core.Interfaces;
using GT86Registry.Infrastructure.Data;
using GT86Registry.Infrastructure.Identity;
using GT86Registry.Web.Interfaces;
using GT86Registry.Web.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GT86Registry.Web
{
    public class Startup
    {
        #region Properties

        public IConfiguration Configuration { get; }

        #endregion Properties

        #region Constructor

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        #endregion Constructor

        #region Methods

        // This method gets called by the runtime.
        // Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
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
                routes.MapRoute(
                     name: "Profile",
                     template: "{username}",
                     defaults: new { controller = "Vehicles", action = "Profile" }
                 );
            });
        }

        // This method gets called by the runtime.
        // Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Setup and configure Identity
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
                {
                    options.Password.RequiredLength = 6;
                    options.Password.RequireNonAlphanumeric = true;
                    options.Password.RequireUppercase = true;
                    options.User.RequireUniqueEmail = true;
                })
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

            // Check out Ardalis article about why we need to use typeof here
            services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));
            services.AddScoped(typeof(IAsyncRepository<>), typeof(EFRepository<>));

            services.AddScoped<VehicleRepository>();
            services.AddTransient<VehicleSeeder>();
            services.AddScoped<IVehicleViewModelService, VehicleViewModelService>();
            services.AddScoped<IUserProfileService, UserProfileService>();
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddScoped<IVehicleFactory, VehicleFactory>();
            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
        }

        #endregion Methods
    }
}