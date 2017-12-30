using GT86Registry.Core.Entities;
using GT86Registry.Core.Interfaces;
using System.Collections.Generic;

namespace GT86Registry.Core.DTOs
{
    /// <summary>
    /// VehicleDto is a light weight representation of a complete Vehicle object
    /// </summary>
    public class VehicleDto : ISocialMediaLinks
    {
        #region Properties

        public string ColorCode { get; set; }
        public string ColorName { get; set; }
        public string Description { get; set; }
        public string FacebookUri { get; set; }
        public string ImageUri { get; set; }
        public string InstagramUri { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Transmission { get; set; }
        public string Username { get; set; }
        public List<Image> VehicleImages { get; set; } = new List<Image>();
        public VehicleLocation VehicleLocation { get; set; }
        public string VIN { get; set; }
        public int Year { get; set; }
        public string Status { get; set; }
        public int ViewCount { get; set; }

        #endregion Properties

        #region Constructors

        public VehicleDto()
        {
        }

        public VehicleDto(Vehicle vehicle)
        {
            VIN = vehicle.VIN;
            Username = vehicle.UserIdentityGuid;
            InstagramUri = vehicle.InstagramUri;
            FacebookUri = vehicle.FacebookUri;
            ImageUri = vehicle.Image.Uri;
            ColorCode = vehicle.Color.Code;
            ColorName = vehicle.Color.Name;
            Description = vehicle.Description;
            Manufacturer = vehicle.ModelYear.Model.Manufacturer.Name;
            Model = vehicle.ModelYear.Model.Name;
            Year = vehicle.ModelYear.Year;
            Transmission = vehicle.Transmission.Name;
            VehicleLocation = new VehicleLocation(vehicle.VehicleLocation.Latitude, vehicle.VehicleLocation.Longitude);
            ViewCount = vehicle.ViewCount;
            Status = vehicle.Status.Name;

            if (vehicle.VehicleImages != null)
            {
                foreach (var vi in vehicle.VehicleImages)
                {
                    VehicleImages.Add(vi.Image);
                }
            }
        }

        #endregion Constructors
    }
}