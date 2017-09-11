namespace NullReferencesDemo.Presentation.Interfaces
{
    using System.Collections.Generic;

    public interface IApplicationServices
    {
        bool IsUserLoggedIn { get; }

        decimal LoggedInUserBalance { get; }

        string LoggedInUsername { get; }

        void Deposit(decimal amount);

        IEnumerable<StockItem> GetAvailableItems();

        bool Login(string username);

        void Logout();

        IPurchaseReport Purchase(string itemName);

        void RegisterUser(string username);
    }
}