namespace NullReferencesDemo.Presentation.Interfaces
{
    public interface IPurchaseReportFactory
    {
        IPurchaseReport CreateFailedPurchase();

        IPurchaseReport CreateNotEnoughMoney(string username, string productName, decimal price);

        IPurchaseReport CreateNotRegistered(string username);

        IPurchaseReport CreateNotSignedIn();

        IPurchaseReport CreateProductNotFound(string username, string productName);

        IPurchaseReport CreateReport(string username, string productName, decimal price);
    }
}