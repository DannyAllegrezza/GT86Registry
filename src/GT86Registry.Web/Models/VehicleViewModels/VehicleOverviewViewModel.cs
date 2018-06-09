using GT86Registry.Core.Entities;
using System;

namespace GT86Registry.Web.Models.VehicleViewModels
{
    public class VehicleOverviewViewModel
    {
        public string ImageUri { get; set; }
        public VehicleLocation Location { get; set; }
        public string OwnerUsername { get; set; }
        public string Title { get; set; }
        public int ViewCount { get; set; }
        public string VIN { get; set; }
        public int Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public DateTimeOffset CreatedDate { get; set; }

        public override string ToString()
        {
            return $"{Year} {Make} {Model}";
        }
    }
}