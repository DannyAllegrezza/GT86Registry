namespace GT86Registry.Core.Entities
{
    public class Car : BaseEntity
    {
        public Color Color { get; set; }
        public int ColorId { get; set; }

        public Year Year { get; set; }
        public int YearId { get; set; }

        public Manufactuer Manufactuer { get; set; }
        public int ManufactuerId { get; set; }

    }
}
