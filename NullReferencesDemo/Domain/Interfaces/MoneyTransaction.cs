namespace NullReferencesDemo.Domain.Interfaces
{
    public class MoneyTransaction
    {
        public MoneyTransaction(decimal amount)
        {
            Amount = amount;
        }

        public decimal Amount { get; }
    }
}