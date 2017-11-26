using System;
using System.Collections.Generic;
using System.Text;

namespace GT86Registry.Core.Entities
{
    /// <summary>
    /// Represents a join table between the Vehicles and VehiclePhotos tables
    /// </summary>
    public class VehiclesVehiclePhotos
    {
        public int VehicleVIN { get; set; }
        public Vehicle Vehicle { get; set; }

        public int VehiclePhotoId { get; set; }
        public VehiclePhoto VehiclePhoto { get; set; }
    }
}
