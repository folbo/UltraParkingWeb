using System;
using Ultra.Core.Infrastructure;

namespace Ultra.Core.Domain.Entities
{
    public class Project : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid AutorId { get; set; }
    }
}