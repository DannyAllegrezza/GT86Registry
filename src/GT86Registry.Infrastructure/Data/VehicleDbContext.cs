using System;
using GT86Registry.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
            modelBuilder.Entity<VehicleModelYear>(ConfigureVehicleModelYear);
            // Use fluent API to setup the explicit relationships between 
            // Color <--> Year
            modelBuilder.Entity<ColorsYears>().
                HasKey(c => new { c.ColorId, c.YearId });

            // Vehicle <--> VehiclePhoto
            modelBuilder.Entity<VehiclesVehiclePhotos>().
                HasKey(c => new { c.VehicleVIN, c.VehiclePhotoId });

            base.OnModelCreating(modelBuilder);
        }

        private void ConfigureVehicleModelYear(EntityTypeBuilder<VehicleModelYear> builder)
        {
            builder.ToTable("VehicleModelYear");

            builder.HasKey(vmy => vmy.Id);

        }

        private void ConfigureManufacturer(EntityTypeBuilder<Manufacturer> builder)
        {
            builder.ToTable("Manufacturer");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Name).IsRequired(true);
            builder.Property(m => m.ActiveStartDate).IsRequired(true);
        }
    }
}
