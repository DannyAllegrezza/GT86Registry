using System;
using System.Collections.Generic;
using System.Text;

namespace GT86Registry.Core.Entities
{
    public class VehicleModelYear
    {
        public int Id { get; set; }

        public Year Year { get; set; }
        public int YearId { get; set; }

        public Manufacturer Manufacturer { get; set; }
        public int ManufacturerId { get; set; }

        public VehicleModel VehicleModel { get; set; }
        public int VehicleModelId { get; set; }
    }
}
