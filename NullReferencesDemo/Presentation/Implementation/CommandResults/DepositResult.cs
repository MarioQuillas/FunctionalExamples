using NullReferencesDemo.Presentation.Interfaces;

namespace NullReferencesDemo.Presentation.Implementation.CommandResults
{
    public class DepositResult : ICommandResult
    {
        public DepositResult(string username, decimal amount, decimal balance)
        {
            Username = username ?? string.Empty;
            Amount = amount;
            Balance = balance;
        }

        public decimal Amount { get; }

        public decimal Balance { get; }

        public string Username { get; }
    }
}