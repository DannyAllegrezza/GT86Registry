using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GT86Registry.Core.Entities
{
    /// <summary>
    /// Represents a specific instance of a Vehicle, which is the principal entity in our domain.
    /// </summary>
    public class Vehicle : BaseEntity
    {

        public string UserIdentityGuid { get; set; }

        /// <summary>
        /// The Vehicle Information Number
        /// </summary>
        public string VIN { get; set; }

        public string Instagram_Uri { get; set; }
        public string Facebook_Uri { get; set; }

        #region Constructors
        public Vehicle(string vin)
        {
            VIN = Validation.VIN.IsValid(vin) ? vin : throw new System.Exception("Invalid VIN");
        }
        #endregion Constructors
        
        #region Navigation Properties
        public Image Image { get; set; }
        public int ProfilePhotoId { get; set; }

        public Color Color { get; set; }
        public int ColorId { get; set; }

        public ModelYear ModelYear { get; set; }
        public int ModelYearId { get; set; }

        public Transmission Transmission { get; set; }
        public int TransmissionId { get; set; }

        public VehicleLocation VehicleLocation { get; set; }
        public int VehicleLocationId { get; set; }
        
        public List<VehiclesImages> VehicleImages { get; set; }
        public List<VehicleLocation> VehicleLocations { get; set; }
        #endregion Navigation Properties

        #region Methods
        #endregion Methods
    }
}
