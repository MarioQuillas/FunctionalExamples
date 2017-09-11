namespace NullReferencesDemo.Presentation.PurchaseReports
{
    using NullReferencesDemo.Presentation.Interfaces;

    public class FailedPurchase : IPurchaseReport
    {
        private static FailedPurchase instance;

        private FailedPurchase()
        {
        }

        public static FailedPurchase Instance
        {
            get
            {
                if (instance == null) instance = new FailedPurchase();
                return instance;
            }
        }
    }
}