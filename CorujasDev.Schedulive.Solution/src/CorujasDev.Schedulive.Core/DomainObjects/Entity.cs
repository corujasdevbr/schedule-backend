using Flunt.Notifications;
using System;

namespace CorujasDev.Schedulive.Core.DomainObjects
{
    public abstract class Entity : Notifiable
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
