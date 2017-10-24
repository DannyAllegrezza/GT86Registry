namespace GT86Registry.Core.Entities
{
    public class Car : BaseEntity
    {
        public string IdentityGuid { get; set; }
        public bool IsManualTransmission { get; set; }
        public string VIN { get; set; }

        public Color Color { get; set; }
        public int ColorId { get; set; }

        public Year Year { get; set; }
        public int YearId { get; set; }

        public Manufactuer Manufactuer { get; set; }
        public int ManufactuerId { get; set; }

    }
}
