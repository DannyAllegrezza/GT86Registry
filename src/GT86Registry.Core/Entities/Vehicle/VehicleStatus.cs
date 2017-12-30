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
        public int Id { get; set; }
        public string Name { get; set; }
        public Status StatusCode { get; set; }

        #endregion Properties

        #region Constructors

        public VehicleStatus()
        {
        }

        public VehicleStatus(string statusName, Status statusCode)
        {
            if (String.IsNullOrEmpty(statusName))
            {
                throw new ArgumentException("Status name cannot be null or empty.");
            }

            Name = statusName;
            StatusCode = statusCode;
        }

        #endregion Constructors

        #region Navigation Properties

        public List<Vehicle> Vehicles { get; set; }

        #endregion Navigation Properties
    }

    public enum Status
    {
        Active,
        TrackCar,
        Sold,
        Totaled,
        Stolen
    }
}