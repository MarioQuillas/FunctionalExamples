namespace NullReferencesDemo.Presentation.Interfaces
{
    public class StockItem
    {
        public StockItem(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name { get; private set; }

        public decimal Price { get; private set; }
    }
}