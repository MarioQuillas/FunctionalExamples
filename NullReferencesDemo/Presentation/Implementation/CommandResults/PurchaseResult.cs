using System;
using NullReferencesDemo.Presentation.Interfaces;

namespace NullReferencesDemo.Presentation.Implementation.CommandResults
{
    public class PurchaseResult : ICommandResult
    {
        public PurchaseResult(IPurchaseReport purchaseReport)
        {
            if (purchaseReport == null) throw new ArgumentNullException(nameof(purchaseReport));

            Report = purchaseReport;
        }

        public IPurchaseReport Report { get; }
    }
}