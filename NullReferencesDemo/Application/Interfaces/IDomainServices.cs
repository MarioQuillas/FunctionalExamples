namespace NullReferencesDemo.Application.Interfaces
{
    using System.Collections.Generic;

    using NullReferencesDemo.Presentation.Interfaces;

    public interface IDomainServices
    {
        void CreateUser(string username);

        void Deposit(string username, decimal amount);

        IEnumerable<StockItem> GetAvailableItems();

        decimal GetBalance(string username);

        bool IsRegistered(string username);

        IPurchaseReport Purchase(string username, string itemName);
    }
}