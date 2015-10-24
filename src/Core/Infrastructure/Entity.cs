using System;

namespace Ultra.Core.Infrastructure
{
    public class Entity
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public virtual Guid Id { get; set; }
    }
}