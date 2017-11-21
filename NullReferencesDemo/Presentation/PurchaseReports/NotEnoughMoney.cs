using NullReferencesDemo.Presentation.Interfaces;

namespace NullReferencesDemo.Presentation.PurchaseReports
{
    public class NotEnoughMoney : IPurchaseReport
    {
        public NotEnoughMoney(string username, string productName, decimal price)
        {
            Username = username;
            Price = price;
            ProductName = productName;
        }

        public decimal Price { get; }

        public string ProductName { get; }

        public string Username { get; }
    }
}