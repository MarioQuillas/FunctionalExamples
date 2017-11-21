using System.Collections.Generic;

namespace DddInPractice.Logic.Common
{
    public abstract class AggregateRoot : Entity
    {
        private readonly List<IDomainEvent> _domainEvents = new List<IDomainEvent>();

        public virtual IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents;

        public virtual void ClearEvents()
        {
            _domainEvents.Clear();
        }

        protected virtual void AddDomainEvent(IDomainEvent newEvent)
        {
            _domainEvents.Add(newEvent);
        }
    }
}