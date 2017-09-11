namespace DddInPractice.Logic.Common
{
    using System.Collections.Generic;

    public abstract class AggregateRoot : Entity
    {
        private readonly List<IDomainEvent> _domainEvents = new List<IDomainEvent>();

        public virtual IReadOnlyList<IDomainEvent> DomainEvents => this._domainEvents;

        public virtual void ClearEvents()
        {
            this._domainEvents.Clear();
        }

        protected virtual void AddDomainEvent(IDomainEvent newEvent)
        {
            this._domainEvents.Add(newEvent);
        }
    }
}