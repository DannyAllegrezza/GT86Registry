using System;
using System.Collections.Generic;

namespace GT86Registry.Core.Entities
{
    /// <summary>
    /// Represents a vehicle manufacturer such a "Subaru", "Toyota" or "Scion"
    /// </summary>
    public class Manufacturer : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset ActiveStartDate { get; set; }
        public DateTimeOffset? ActiveEndDate { get; set; }

        public Manufacturer(string name, DateTime activeStartDate, DateTime activeEndDate)
        {
            Name = name;
            ActiveStartDate = activeStartDate;
            ActiveEndDate = activeEndDate;
        }

        #region Navigation Properties
        public List<Model> VehicleModels { get; set; }
        #endregion Navigation Properties
    }
}