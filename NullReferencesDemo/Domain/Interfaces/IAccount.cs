namespace NullReferencesDemo.Domain.Interfaces
{
    using NullReferencesDemo.Common;

    public interface IAccount
    {
        decimal Balance { get; }

        MoneyTransaction Deposit(decimal amount);

        Option<MoneyTransaction> TryWithdraw(decimal amount);
    }
}