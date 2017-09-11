namespace NullReferencesDemo.Infrastructure.Implementation
{
    using NullReferencesDemo.Domain.Interfaces;

    internal class ProductData : IProduct
    {
        public ProductData(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name { get; private set; }

        public decimal Price { get; private set; }
    }
}