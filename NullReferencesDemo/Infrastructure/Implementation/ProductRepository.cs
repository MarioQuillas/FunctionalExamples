using System.Collections.Generic;
using System.Linq;
using NullReferencesDemo.Common;
using NullReferencesDemo.Domain.Interfaces;

namespace NullReferencesDemo.Infrastructure.Implementation
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDictionary<string, decimal> nameToPrice;

        public ProductRepository()
        {
            nameToPrice = new Dictionary<string, decimal>();

            nameToPrice.Add("book", 27.46M);
            nameToPrice.Add("pen", 6.28M);
            nameToPrice.Add("ruler", 2.86M);
        }

        public IEnumerable<IProduct> GetAll()
        {
            return nameToPrice.Select(pair => new ProductData(pair.Key, pair.Value));
        }

        public Option<IProduct> TryFind(string name)
        {
            decimal price;
            if (nameToPrice.TryGetValue(name, out price))
                return Option<IProduct>.Create(new ProductData(name, price));

            return Option<IProduct>.CreateEmpty();
        }
    }
}