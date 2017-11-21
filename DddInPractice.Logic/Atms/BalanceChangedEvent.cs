using DddInPractice.Logic.Common;

namespace DddInPractice.Logic.Atms
{
    public class BalanceChangedEvent : IDomainEvent
    {
        public BalanceChangedEvent(decimal delta)
        {
            Delta = delta;
        }

        public decimal Delta { get; }
    }
}