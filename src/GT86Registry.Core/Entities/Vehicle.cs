using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GT86Registry.Core.Entities
{
    /// <summary>
    /// Represents a specific instance of a Vehicle, which is the principal entity in our domain.
    /// </summary>
    public class Vehicle : BaseEntity
    {
        public int Id { get; set; }
        [Required]
        public string UserIdentityGuid { get; set; }

        [Required]
        public string VIN { get; set; }

        #region Constructors
        public Vehicle(string vin, Year year, VehicleModel model, Color color)
        {
            VIN = Validation.VIN.IsValid(vin) ? vin : throw new System.Exception("Invalid VIN");
            Year = year;
            VehicleModel = model;
            Color = color;

        }
        #endregion Constructors
        
        #region Navigation Properties
        public Color Color { get; set; }
        public int ColorId { get; set; }

        public Year Year { get; set; }
        public int YearId { get; set; }


        public VehicleModel VehicleModel { get; set; }
        public int VehicleModelId { get; set; }

        public VehicleLocation Location { get; set; }
        
        public List<VehiclesVehiclePhotos> VehiclesPhotos { get; set; }
        #endregion Navigation Properties

        #region Methods
        #endregion Methods
    }
}
