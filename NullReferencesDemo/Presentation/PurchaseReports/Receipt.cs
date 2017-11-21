using NullReferencesDemo.Presentation.Interfaces;

namespace NullReferencesDemo.Presentation.PurchaseReports
{
    public class Receipt : IPurchaseReport
    {
        public Receipt(string username, string productName, decimal price)
        {
            Username = username;
            ProductName = productName;
            Price = price;
        }

        public decimal Price { get; }

        public string ProductName { get; }

        public string Username { get; }
    }
}