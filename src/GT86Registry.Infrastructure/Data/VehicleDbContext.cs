using GT86Registry.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GT86Registry.Infrastructure.Data
{
    public class VehicleDbContext : DbContext
    {
        private DbSet<Vehicle> Vehicles { get; set; }
        private DbSet<Color> Colors { get; set; }
        private DbSet<ModelYear> Years { get; set; }
        private DbSet<ColorsModelYears> ColorYears { get; set; }
        private DbSet<Manufacturer> Manufacturers { get; set; }
        private DbSet<Model> VehicleModels { get; set; }

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
            modelBuilder.Entity<Manufacturer>(ConfigureManufacturer);
            modelBuilder.Entity<Model>(ConfigureVehicleModel);
            modelBuilder.Entity<ModelYear>(ConfigureModelYear);
            modelBuilder.Entity<ColorsModelYears>(ConfigureModelColor);
            modelBuilder.Entity<ModelTransmissions>(ConfigureModelTransmissions);
            modelBuilder.Entity<VehiclesImages>(ConfigureVehicleImages);
            modelBuilder.Entity<Vehicle>(ConfigureVehicle);
            modelBuilder.Entity<VehicleLocation>(ConfigureVehicleLocation);
        }

        private void ConfigureManufacturer(EntityTypeBuilder<Manufacturer> builder)
        {
            builder.ToTable("Manufacturer");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Name).IsRequired(true);
            builder.Property(m => m.ActiveStartDate).IsRequired(true);
        }

        private void ConfigureVehicleModel(EntityTypeBuilder<Model> builder)
        {
            builder.ToTable("Model");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Name).IsRequired(true);
        }

        private void ConfigureModelYear(EntityTypeBuilder<ModelYear> builder)
        {
            builder.ToTable("ModelYear");
            builder.HasOne(my => my.Model)
                .WithMany(m => m.ModelYears)
                .HasForeignKey(my => my.ModelId);
            builder.HasKey(my => my.Id);

        }

        private void ConfigureModelColor(EntityTypeBuilder<ColorsModelYears> builder)
        {
            builder.ToTable("ModelColor");
            builder.HasKey(c => new { c.ColorId, c.ModelYearId });
        }

        private void ConfigureModelTransmissions(EntityTypeBuilder<ModelTransmissions> builder)
        {
            builder.ToTable("ModelTransmission");
            builder.HasKey(m => new { m.ModelYearId, m.TransmissionId });
        }

        private void ConfigureVehicleImages(EntityTypeBuilder<VehiclesImages> builder)
        {
            builder.ToTable("VehicleImage");
            builder.HasKey(v => new { v.VehicleId, v.ImageId });
        }

        private void ConfigureVehicle(EntityTypeBuilder<Vehicle> builder)
        {
            builder.ToTable("Vehicle");
            builder.HasKey(v => v.VIN);
            builder.Property(v => v.VIN).HasMaxLength(17);

            builder.HasOne(i => i.Image)
                .WithMany(v => v.Vehicles)
                .HasForeignKey(v => v.ProfilePhotoId);

        }

        private void ConfigureVehicleLocation(EntityTypeBuilder<VehicleLocation> builder)
        {
            builder.ToTable("Location");
            builder.HasKey(v => v.Id);
            builder.HasOne(l => l.Vehicle)
                .WithMany(l => l.VehicleLocations);
        }
    }
}