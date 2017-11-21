using NullReferencesDemo.Presentation.Interfaces;

namespace NullReferencesDemo.Domain.Interfaces
{
    public interface IUser
    {
        decimal Balance { get; }

        string Username { get; }

        void Deposit(decimal amount);

        IPurchaseReport Purchase(IProduct product);
    }
}