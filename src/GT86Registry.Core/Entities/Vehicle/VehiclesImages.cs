namespace GT86Registry.Core.Entities
{
    /// <summary>
    /// Represents a join table between the Vehicles and Images tables
    /// </summary>
    public class VehiclesImages
    {
        public Image Image { get; set; }
        public int ImageId { get; set; }
        public Vehicle Vehicle { get; set; }
        public string VehicleVIN { get; set; }
    }
}