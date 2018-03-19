using GT86Registry.Core.Interfaces;
using GT86Registry.Core.Interfaces.Entities;
using System.Collections.Generic;

namespace GT86Registry.Core.Entities
{
    /// <summary>
    /// Represents a specific instance of a Vehicle, which is the principal entity in our domain.
    /// </summary>
    public class Vehicle : BaseEntity, ISocialMediaLinks, IVehicle
    {
        public string UserIdentityGuid { get; set; }

        /// <summary>
        /// The Vehicle Information Number
        /// </summary>
        public string VIN { get; set; }
        public int Mileage { get; set; }
        public string InstagramUri { get; set; }
        public string FacebookUri { get; set; }
        public string Description { get; set; }
        public int ViewCount { get; set; } = 0;

        #region Constructors

        protected Vehicle()
        {
        }

        public Vehicle(string vin)
        {
            VIN = Validation.VIN.IsValid(vin) ? vin : throw new System.Exception("Invalid VIN");
        }

        public Vehicle(string vin, 
                    ModelYear modelYear, 
                    Color color, 
                    Transmission transmission,
                    string userIdentityGuid)
        {
            VIN = Validation.VIN.IsValid(vin) ? vin : throw new System.Exception("Invalid VIN");
            ModelYear = modelYear;
            Color = color;
            Transmission = transmission;
            UserIdentityGuid = userIdentityGuid;            
        }

        
        #endregion Constructors

        #region Navigation Properties

        public VehicleStatus Status { get; set; }
        public int StatusId { get; set; }

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

        public List<VehiclesImages> VehicleImages { get; set; } = new List<VehiclesImages>();

        public override string ToString()
        {
            return $"{ModelYear.Year} {ModelYear.Model.Manufacturer.Name} {ModelYear.Model.Name}";
        }

        #endregion Navigation Properties
    }
}