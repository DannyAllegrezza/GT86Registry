namespace GT86Registry.Core.Entities
{
    public class ColorsYears
    {
        public int ColorId { get; set; }
        public Color Color { get; set; }

        public int YearId { get; set; }
        public Year Year { get; set; }

        public int ManufactuerId { get; set; }
        public Manufactuer Manufactuer { get; set; }
    }
}