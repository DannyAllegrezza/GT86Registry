namespace GT86Registry.Core.Entities
{
    /// <summary>
    /// Represents a vehicle Manufacturer.
    /// </summary>
    public class Manufacturer : BaseEntity
    {
        public string Name { get; set; }
        public bool IsInProduction { get; set; }
    }
}