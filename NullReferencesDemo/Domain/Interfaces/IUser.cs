namespace NullReferencesDemo.Domain.Interfaces
{
    using NullReferencesDemo.Presentation.Interfaces;

    public interface IUser
    {
        decimal Balance { get; }

        string Username { get; }

        void Deposit(decimal amount);

        IPurchaseReport Purchase(IProduct product);
    }
}