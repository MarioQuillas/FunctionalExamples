using NullReferencesDemo.Presentation.Interfaces;

namespace NullReferencesDemo.Presentation.PurchaseReports
{
    public class ProductNotFound : IPurchaseReport
    {
        public ProductNotFound(string username, string productName)
        {
            Username = username;
            ProductName = productName;
        }

        public string ProductName { get; }

        public string Username { get; }
    }
}