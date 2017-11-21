using NullReferencesDemo.Application.Implementation;
using NullReferencesDemo.Domain.Implementation;
using NullReferencesDemo.Infrastructure.Implementation;
using NullReferencesDemo.Presentation.Implementation;
using NullReferencesDemo.Presentation.Implementation.CommandResults;
using NullReferencesDemo.Presentation.Interfaces;
using NullReferencesDemo.Presentation.PurchaseReports;
using NullReferencesDemo.Presentation.Views;

namespace NullReferencesDemo
{
    internal class Program
    {
        private static TPurchaseReport Cast<TPurchaseReport>(ICommandResult cmdResult)
            where TPurchaseReport : IPurchaseReport
        {
            if (!(cmdResult is PurchaseResult purchaseResult)) return default(TPurchaseReport);

            var report = purchaseResult.Report;

            return (TPurchaseReport) report;
        }

        private static void Main(string[] args)
        {
            IPurchaseReportFactory reportFactory = new PurchaseReportFactory();

            var viewLocator = SetupViewLocator();

            var ui = new UserInterface(
                new ApplicationServices(
                    new DomainServices(new UserRepository(), new ProductRepository(), reportFactory),
                    reportFactory),
                viewLocator);

            while (ui.ReadCommand())
                ui.ExecuteCommand();
        }

        private static bool PurchaseSelector<TPurchaseReport>(ICommandResult cmdResult)
            where TPurchaseReport : IPurchaseReport
        {
            if (!(cmdResult is PurchaseResult purchaseResult)) return false;

            return purchaseResult.Report.GetType() == typeof(TPurchaseReport);
        }

        private static bool Selector<TCommand>(ICommandResult cmdResult)
            where TCommand : ICommandResult
        {
            return cmdResult != null && cmdResult.GetType() == typeof(TCommand);
        }

        private static ViewLocator SetupViewLocator()
        {
            var viewLocator = new ViewLocator();

            viewLocator.RegisterService(Selector<DepositResult>, obj => new DepositView((DepositResult) obj));
            viewLocator.RegisterService(Selector<LoginFailed>, obj => new LoginFailedView((LoginFailed) obj));
            viewLocator.RegisterService(Selector<UserLoggedIn>, obj => new UserLoggedInView((UserLoggedIn) obj));
            viewLocator.RegisterService(Selector<UserLoggedOut>, obj => new UserLoggedOutView((UserLoggedOut) obj));
            viewLocator.RegisterService(Selector<UserRegistered>, obj => new UserRegisteredView((UserRegistered) obj));

            viewLocator.RegisterService(PurchaseSelector<FailedPurchase>, obj => new FailedPurchaseView());
            viewLocator.RegisterService(
                PurchaseSelector<NotEnoughMoney>,
                obj => new NotEnoughMoneyView(Cast<NotEnoughMoney>(obj)));
            viewLocator.RegisterService(
                PurchaseSelector<NotRegistered>,
                obj => new NotRegisteredView(Cast<NotRegistered>(obj)));
            viewLocator.RegisterService(PurchaseSelector<NotSignedIn>, obj => new NotSignedInView());
            viewLocator.RegisterService(
                PurchaseSelector<ProductNotFound>,
                obj => new ProductNotFoundView(Cast<ProductNotFound>(obj)));
            viewLocator.RegisterService(PurchaseSelector<Receipt>, obj => new ReceiptView(Cast<Receipt>(obj)));

            return viewLocator;
        }
    }
}