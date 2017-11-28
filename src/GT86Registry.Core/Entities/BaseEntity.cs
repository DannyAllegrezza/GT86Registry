using System;

namespace GT86Registry.Core.Entities
{
    public abstract class BaseEntity
    {
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public BaseEntity()
        {
            CreatedDate = DateTime.UtcNow;
        }
    }
}
