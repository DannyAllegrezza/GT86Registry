using System;
using System.Collections.Generic;
using System.Text;

namespace GT86Registry.Core.Entities
{
    /// <summary>
    /// Represents a join table between the Vehicles and VehiclePhotos tables
    /// </summary>
    public class VehiclesImages
    {
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }

        public int ImageId { get; set; }
        public Image Image { get; set; }
    }
}
