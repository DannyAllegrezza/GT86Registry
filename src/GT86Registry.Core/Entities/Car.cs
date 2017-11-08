using System.ComponentModel.DataAnnotations;

namespace GT86Registry.Core.Entities
{
    /// <summary>
    /// Represents a specific instance of a Car, which is the principal entity in our domain.
    /// </summary>
    public class Car : BaseEntity
    {
        [Required]
        public string IdentityGuid { get; set; }

        [Required]
        [MaxLength(17)]
        public string VIN { get; set; }

        public Color Color { get; set; }
        public int ColorId { get; set; }

        public Year Year { get; set; }
        public int YearId { get; set; }

        public CarModel CarModel { get; set; }
    }
}
