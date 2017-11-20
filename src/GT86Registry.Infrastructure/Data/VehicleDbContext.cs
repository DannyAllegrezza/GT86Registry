using GT86Registry.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace GT86Registry.Infrastructure.Data
{
    public class VehicleDbContext : DbContext
    {
        DbSet<Vehicle> Vehicles { get; set; }
        DbSet<Color> Colors { get; set; }
        DbSet<Year> Years { get; set; }
        DbSet<ColorsYears> ColorYears { get; set; }
        DbSet<Manufacturer> Manufacturers { get; set; }
        DbSet<VehicleModel> VehicleModels { get; set; }

        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options">The database context options</param>
        public VehicleDbContext(DbContextOptions<VehicleDbContext> options) : base(options)
        {

        }
        #endregion Constructors

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Use fluent API to setup the explicit relationships between 
            // Color <--> Year
            modelBuilder.Entity<ColorsYears>().
                HasKey(c => new { c.ColorId, c.YearId });

            // Vehicle <--> VehiclePhoto
            modelBuilder.Entity<VehiclesVehiclePhotos>().
                HasKey(c => new { c.VehicleId, c.VehiclePhotoId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
