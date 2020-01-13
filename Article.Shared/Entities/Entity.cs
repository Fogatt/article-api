using System;
using FluentValidator;

namespace Article.Shared.Entities
{
    //that class cannot be inherited by structures
    public abstract class Entity : Notifiable
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }

        public void UpdateId(Guid id)
        {
            this.Id = id;
        }
        
    }
}