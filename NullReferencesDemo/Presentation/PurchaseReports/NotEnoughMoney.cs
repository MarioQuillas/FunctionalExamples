namespace NullReferencesDemo.Presentation.PurchaseReports
{
    using NullReferencesDemo.Presentation.Interfaces;

    public class NotEnoughMoney : IPurchaseReport
    {
        public NotEnoughMoney(string username, string productName, decimal price)
        {
            this.Username = username;
            this.Price = price;
            this.ProductName = productName;
        }

        public decimal Price { get; }

        public string ProductName { get; }

        public string Username { get; }
    }
}