namespace NullReferencesDemo.Presentation.PurchaseReports
{
    using NullReferencesDemo.Presentation.Interfaces;

    public class Receipt : IPurchaseReport
    {
        public Receipt(string username, string productName, decimal price)
        {
            this.Username = username;
            this.ProductName = productName;
            this.Price = price;
        }

        public decimal Price { get; }

        public string ProductName { get; }

        public string Username { get; }
    }
}