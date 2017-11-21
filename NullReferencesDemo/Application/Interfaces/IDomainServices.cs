using System.Collections.Generic;
using NullReferencesDemo.Presentation.Interfaces;

namespace NullReferencesDemo.Application.Interfaces
{
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