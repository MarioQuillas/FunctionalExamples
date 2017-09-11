namespace NullReferencesDemo.Domain.Interfaces
{
    using System.Collections.Generic;

    using NullReferencesDemo.Common;

    public interface IProductRepository
    {
        IEnumerable<IProduct> GetAll();

        Option<IProduct> TryFind(string name);
    }
}