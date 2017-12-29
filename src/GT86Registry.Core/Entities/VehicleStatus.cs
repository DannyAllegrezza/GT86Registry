using System;
using System.Collections.Generic;

namespace GT86Registry.Core.Entities
{
    /// <summary>
    /// Represents the status of a Vehicle, ie: "Currently Owned", "Sold", "Wrecked", "Stolen".
    /// </summary>
    public class VehicleStatus
    {
        #region Properties
        public static string Active = "Active";
        public int Id { get; set; }
        public string Name { get; set; }

        #endregion Properties

        #region Constructors

        public VehicleStatus()
        {
        }

        public VehicleStatus(string statusName)
        {
            if (String.IsNullOrEmpty(statusName))
            {
                throw new ArgumentException("Status name cannot be null or empty.");
            }

            Name = statusName;
        }

        #endregion Constructors

        #region Navigation Properties

        public List<Vehicle> Vehicles { get; set; }

        #endregion Navigation Properties
    }
}