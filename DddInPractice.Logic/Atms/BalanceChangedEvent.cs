namespace DddInPractice.Logic.Atms
{
    using DddInPractice.Logic.Common;

    public class BalanceChangedEvent : IDomainEvent
    {
        public BalanceChangedEvent(decimal delta)
        {
            this.Delta = delta;
        }

        public decimal Delta { get; private set; }
    }
}