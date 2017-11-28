using System;
using System.Collections.Generic;
using System.Text;

namespace GT86Registry.Core.Entities
{
    public class Image : BaseEntity
    {
        public int Id { get; set; }
        public string Uri { get; set; }
        public List<Vehicle> Vehicles { get; set; }
        public List<VehiclesImages> VehicleImages { get; set; }
    }
}
