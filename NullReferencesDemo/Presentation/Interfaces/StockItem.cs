namespace NullReferencesDemo.Presentation.Interfaces
{
    public class StockItem
    {
        public StockItem(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; }

        public decimal Price { get; }
    }
}