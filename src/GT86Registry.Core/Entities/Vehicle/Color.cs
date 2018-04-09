using System.Collections.Generic;

namespace GT86Registry.Core.Entities
{
    public class Color : BaseEntity
    {
        public string Code { get; set; }
        public string HexValue { get; set; }
        public int Id { get; set; }

        public string Name { get; set; }

        #region Constructors

        public Color(string name, string code)
        {
            Name = name;
            Code = code;
        }

        protected Color()
        {
        }

        #endregion Constructors

        #region Navigation Properties

        public virtual List<ColorsModelYears> ModelColors { get; set; } = new List<ColorsModelYears>();
        public virtual List<Vehicle> Vehicles { get; set; } = new List<Vehicle>();

        #endregion Navigation Properties
    }
}