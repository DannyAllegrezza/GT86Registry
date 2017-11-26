using System;
using System.Collections.Generic;

namespace GT86Registry.Core.Entities
{
    /// <summary>
    /// Represents a vehicle Manufacturer such a "Subaru", "Toyota" or "Scion"
    /// </summary>
    public class Manufacturer : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ActiveStartDate { get; set; }
        public DateTime ActiveEndDate { get; set; }

        public Manufacturer(string name, DateTime activeStartDate, DateTime activeEndDate)
        {
            Name = name;
            ActiveStartDate = activeStartDate;
            ActiveEndDate = activeEndDate;
        }

        public List<VehicleModel> VehicleModels { get; set; }
        public List<VehicleModelYear> VehicleModelYear { get; set; }
    }
}