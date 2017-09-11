namespace DddInPractice.Logic.Utils
{
    using DddInPractice.Logic.Common;

    using NHibernate.Event;

    internal class EventListener : IPostInsertEventListener,
                                   IPostDeleteEventListener,
                                   IPostUpdateEventListener,
                                   IPostCollectionUpdateEventListener
    {
        public void OnPostDelete(PostDeleteEvent ev)
        {
            this.DispatchEvents(ev.Entity as AggregateRoot);
        }

        public void OnPostInsert(PostInsertEvent ev)
        {
            this.DispatchEvents(ev.Entity as AggregateRoot);
        }

        public void OnPostUpdate(PostUpdateEvent ev)
        {
            this.DispatchEvents(ev.Entity as AggregateRoot);
        }

        public void OnPostUpdateCollection(PostCollectionUpdateEvent ev)
        {
            this.DispatchEvents(ev.AffectedOwnerOrNull as AggregateRoot);
        }

        private void DispatchEvents(AggregateRoot aggregateRoot)
        {
            if (aggregateRoot == null) return;

            foreach (IDomainEvent domainEvent in aggregateRoot.DomainEvents)
            {
                DomainEvents.Dispatch(domainEvent);
            }

            aggregateRoot.ClearEvents();
        }
    }
}