using System;

namespace GT86Registry.Core.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime ModifiedDate { get; set; }

        public BaseEntity()
        {
            CreatedDate = DateTime.UtcNow;
        }
    }
}
