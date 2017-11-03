using System.ComponentModel.DataAnnotations;

namespace GT86Registry.Core.Entities
{
    /// <summary>
    /// Represents a Car, which is the principal entity in our domain.
    /// </summary>
    public class Car : BaseEntity
    {
        public string IdentityGuid { get; set; }

        public bool IsManualTransmission { get; set; }

        public string VIN { get; set; }

        public Color Color { get; set; }
        public int ColorId { get; set; }

        public Year Year { get; set; }
        public int YearId { get; set; }

        public CarModel CarModel { get; set; }
        public Manufacturer Manufacturer { get; set; }

    }
}
