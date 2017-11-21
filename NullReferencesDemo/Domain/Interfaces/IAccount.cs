using NullReferencesDemo.Common;

namespace NullReferencesDemo.Domain.Interfaces
{
    public interface IAccount
    {
        decimal Balance { get; }

        MoneyTransaction Deposit(decimal amount);

        Option<MoneyTransaction> TryWithdraw(decimal amount);
    }
}