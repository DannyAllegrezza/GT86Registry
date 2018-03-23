using GT86Registry.Core.Entities;

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
    }
}