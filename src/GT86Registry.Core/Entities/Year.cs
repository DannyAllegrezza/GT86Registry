using System.Collections.Generic;

namespace GT86Registry.Core.Entities
{
    /// <summary>
    /// Represents the year of vehicle
    /// </summary>
    public class Year : BaseEntity
    {
        /// <summary>
        /// The value of the year (ex: 2014)
        /// </summary>
        public int Value { get; set; }

        public List<ColorsYears> ColorYears { get; set; }
    }
}