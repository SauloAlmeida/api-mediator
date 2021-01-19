using System;

namespace ApiMediator.Core.Base.Model
{
    public abstract class Entity
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public DateTime CreatedAt { get; private set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
    }
}
