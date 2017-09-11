namespace NullReferencesDemo.Presentation.Implementation.CommandResults
{
    using NullReferencesDemo.Presentation.Interfaces;

    public class DepositResult : ICommandResult
    {
        public DepositResult(string username, decimal amount, decimal balance)
        {
            this.Username = username ?? string.Empty;
            this.Amount = amount;
            this.Balance = balance;
        }

        public decimal Amount { get; }

        public decimal Balance { get; }

        public string Username { get; }
    }
}