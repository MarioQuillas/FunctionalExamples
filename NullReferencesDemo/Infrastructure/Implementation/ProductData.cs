using NullReferencesDemo.Domain.Interfaces;

namespace NullReferencesDemo.Infrastructure.Implementation
{
    internal class ProductData : IProduct
    {
        public ProductData(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; }

        public decimal Price { get; }
    }
}