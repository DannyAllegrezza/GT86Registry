using GT86Registry.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace GT86Registry.Infrastructure.Data
{
    public class CarDbContext : DbContext
    {
        DbSet<Car> Cars { get; set; }
        DbSet<Color> Colors { get; set; }
        DbSet<Year> Years { get; set; }
        DbSet<ColorsYears> ColorYears { get; set; }
        DbSet<Manufacturer> Manufacturers { get; set; }
        DbSet<CarModel> CarModels { get; set; }

        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options">The database context options</param>
        public CarDbContext(DbContextOptions<CarDbContext> options) : base(options)
        {

        }
        #endregion Constructors

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Use fluent API to setup the explicit relationship between Color <--> Year
            modelBuilder.Entity<ColorsYears>().
                HasKey(c => new { c.ColorId, c.YearId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
