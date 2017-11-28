using System;

namespace GT86Registry.Core.Entities
{
    public abstract class BaseEntity
    {
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset ModifiedDate { get; set; }

        public BaseEntity()
        {
            CreatedDate = DateTimeOffset.UtcNow;
        }
    }
}
