using System.Collections.Generic;

namespace GT86Registry.Core.Entities
{
    public class VehiclePhoto : BaseEntity
    {
        public int Id { get; set; }
        public string PictureUri { get; set; }
        public string ThumbnailUri { get; set; }

        public List<VehiclesVehiclePhotos> VehiclesPhotos { get; set; }
    }
}