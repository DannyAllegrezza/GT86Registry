using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GT86Registry.Core.Entities
{
    /// <summary>
    /// Represents a specific instance of a Vehicle, which is the principal entity in our domain.
    /// </summary>
    public class Vehicle : BaseEntity
    {
        [Required]
        public string UserIdentityGuid { get; set; }

        [Key]
        [Required]
        public string VIN { get; set; }

        #region Constructors
        public Vehicle(string vin, VehicleModel model, Color color)
        {
            VIN = Validation.VIN.IsValid(vin) ? vin : throw new System.Exception("Invalid VIN");
            VehicleModel = model;
            Color = color;
        }
        #endregion Constructors
        
        #region Navigation Properties
        public Color Color { get; set; }
        public int ColorId { get; set; }

        public VehicleModel VehicleModel { get; set; }
        public int VehicleModelId { get; set; }

        public VehicleLocation Location { get; set; }
        
        public List<VehiclesVehiclePhotos> VehiclesPhotos { get; set; }
        #endregion Navigation Properties

        #region Methods
        #endregion Methods
    }
}
