using NullReferencesDemo.Common;
using System.Collections.Generic;

namespace NullReferencesDemo.Domain.Interfaces
{
    public interface ITransactionSelector
    {
        Option<MoneyTransaction> TrySelectOne(IEnumerable<MoneyTransaction> transactions,
                                              decimal maxAmount);
    }
}
