namespace NullReferencesDemo.Domain.Interfaces
{
    using System.Collections.Generic;

    using NullReferencesDemo.Common;

    public interface ITransactionSelector
    {
        Option<MoneyTransaction> TrySelectOne(IEnumerable<MoneyTransaction> transactions, decimal maxAmount);
    }
}