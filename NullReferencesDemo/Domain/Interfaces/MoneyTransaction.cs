namespace NullReferencesDemo.Domain.Interfaces
{
    public class MoneyTransaction
    {
        public MoneyTransaction(decimal amount)
        {
            this.Amount = amount;
        }

        public decimal Amount { get; private set; }
    }
}