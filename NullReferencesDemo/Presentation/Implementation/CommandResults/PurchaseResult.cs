namespace NullReferencesDemo.Presentation.Implementation.CommandResults
{
    using System;

    using NullReferencesDemo.Presentation.Interfaces;

    public class PurchaseResult : ICommandResult
    {
        public PurchaseResult(IPurchaseReport purchaseReport)
        {
            if (purchaseReport == null) throw new ArgumentNullException(nameof(purchaseReport));

            this.Report = purchaseReport;
        }

        public IPurchaseReport Report { get; }
    }
}