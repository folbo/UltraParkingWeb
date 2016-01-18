using System;
using Ultra.Core.Infrastructure;

namespace Ultra.Core.Domain.Entities
{
    public class Owner : IEntity
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
    }
}