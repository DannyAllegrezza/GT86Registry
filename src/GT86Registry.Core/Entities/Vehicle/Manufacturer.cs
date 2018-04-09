using System;
using System.Collections.Generic;

namespace GT86Registry.Core.Entities
{
    /// <summary>
    /// Represents a vehicle manufacturer such a "Subaru", "Toyota" or "Scion"
    /// </summary>
    public class Manufacturer : BaseEntity
    {
        public DateTime? ActiveEndDate { get; set; }
        public DateTime ActiveStartDate { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }

        #region Constructors

        public Manufacturer(string name, DateTime activeStartDate, DateTime? activeEndDate)
        {
            Name = name;
            ActiveStartDate = activeStartDate;
            ActiveEndDate = activeEndDate;
        }

        protected Manufacturer()
        {
        }

        #endregion Constructors

        #region Navigation Properties

        public List<Model> VehicleModels { get; set; }

        #endregion Navigation Properties
    }
}