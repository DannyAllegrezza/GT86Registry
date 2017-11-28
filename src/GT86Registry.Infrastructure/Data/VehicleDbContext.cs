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
            modelBuilder.Entity<BaseEntity>(ConfigureBaseEntity);
            modelBuilder.Entity<Manufacturer>(ConfigureManufacturer);
            modelBuilder.Entity<Model>(ConfigureVehicleModel);
            modelBuilder.Entity<ModelYear>(ConfigureModelYear);
            modelBuilder.Entity<Color>(ConfigureColor);
            modelBuilder.Entity<ColorsModelYears>(ConfigureModelColor);
            modelBuilder.Entity<ModelTransmissions>(ConfigureModelTransmissions);
            modelBuilder.Entity<VehiclesImages>(ConfigureVehicleImages);
            modelBuilder.Entity<Vehicle>(ConfigureVehicle);
            modelBuilder.Entity<VehicleLocation>(ConfigureVehicleLocation);
        }

        private void ConfigureBaseEntity(EntityTypeBuilder<BaseEntity> builder)
        {
            builder.Property(m => m.CreatedDate).IsRequired(true);
            builder.Property(m => m.ModifiedDate).IsRequired(false);
        }

        private void ConfigureManufacturer(EntityTypeBuilder<Manufacturer> builder)
        {
            builder.ToTable("Manufacturer");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Name).IsRequired(true).HasMaxLength(150);
            builder.Property(m => m.ActiveStartDate).IsRequired(true);
            builder.Property(m => m.ActiveEndDate).IsRequired(false);
        }

        private void ConfigureVehicleModel(EntityTypeBuilder<Model> builder)
        {
            builder.ToTable("Model");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Name).IsRequired(true).HasMaxLength(100);
        }

        private void ConfigureModelYear(EntityTypeBuilder<ModelYear> builder)
        {
            builder.ToTable("Model_Year");
            builder.HasKey(my => my.Id);
            builder.HasOne(my => my.Model)
                .WithMany(m => m.ModelYears)
                .HasForeignKey(my => my.ModelId);
        }

        private void ConfigureColor(EntityTypeBuilder<Color> builder)
        {
            builder.ToTable("Color");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Code).IsRequired(true).HasMaxLength(50);
        }

        private void ConfigureModelColor(EntityTypeBuilder<ColorsModelYears> builder)
        {
            builder.ToTable("Model_Color");
            builder.HasKey(c => new { c.ColorId, c.ModelYearId });
        }

        private void ConfigureTransmission(EntityTypeBuilder<Transmission> builder)
        {
            builder.ToTable("Transmission");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).IsRequired(true).HasMaxLength(100);
        }

        private void ConfigureModelTransmissions(EntityTypeBuilder<ModelTransmissions> builder)
        {
            builder.ToTable("Model_Transmission");
            builder.HasKey(m => new { m.ModelYearId, m.TransmissionId });
        }

        private void ConfigureVehicleImages(EntityTypeBuilder<VehiclesImages> builder)
        {
            builder.ToTable("Vehicle_Image");
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