namespace NullReferencesDemo.Presentation.PurchaseReports
{
    using NullReferencesDemo.Presentation.Interfaces;

    public class ProductNotFound : IPurchaseReport
    {
        public ProductNotFound(string username, string productName)
        {
            this.Username = username;
            this.ProductName = productName;
        }

        public string ProductName { get; }

        public string Username { get; }
    }
}