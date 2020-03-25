using MoneyControl.Domain.Interfaces;
using System;

namespace MoneyControl.Domain.Shared
{
    public abstract class Entity: IEntity
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
    }
}
