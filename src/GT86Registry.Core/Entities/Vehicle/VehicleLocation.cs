using System;
using System.Collections.Generic;

namespace GT86Registry.Core.Entities
{
    public class VehicleLocation : BaseEntity
    {
        private double _latitude;
        private double _longitude;

        public VehicleLocation(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        protected VehicleLocation()
        {
        }

        public int Id { get; set; }

        public double Latitude
        {
            get
            {
                return _latitude;
            }
            set
            {
                if (value > 90)
                {
                    throw new ArgumentOutOfRangeException(null, "The Latitude cannot be greater than 90. Please adjust the value accordingly!");
                }
                if (value < -90)
                {
                    throw new ArgumentOutOfRangeException(null, "The Latitude cannot be less than -90. Please adjust the value accordingly!");
                }
                _latitude = value;
            }
        }

        public double Longitude
        {
            get
            {
                return _longitude;
            }
            set
            {
                if (value > 180)
                {
                    throw new ArgumentOutOfRangeException(null, "The Longitude cannot be greater than 180. Please adjust the value accordingly!");
                }
                if (value < -180)
                {
                    throw new ArgumentOutOfRangeException(null, "The Longitude cannot be less than -180. Please adjust the value accordingly!");
                }
                _longitude = value;
            }
        }

        public DateTimeOffset TimeStamp { get; set; }

        public List<Vehicle> Vehicles { get; set; }
    }
}