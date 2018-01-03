namespace GT86Registry.Core.Entities
{
    /// <summary>
    /// Represents a join table between the Vehicles and Images tables
    /// </summary>
    public class VehiclesImages
    {
        public string VehicleVIN { get; set; }
        public Vehicle Vehicle { get; set; }

        public int ImageId { get; set; }
        public Image Image { get; set; }
    }
}