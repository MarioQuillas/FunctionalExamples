using System.Linq;
using NullReferencesDemo.Domain.Interfaces;
using NullReferencesDemo.Presentation.Interfaces;
using NullReferencesDemo.Presentation.PurchaseReports;

namespace NullReferencesDemo.Domain.Implementation
{
    internal class User : IUser
    {
        private readonly IAccount account;

        private readonly IPurchaseReportFactory reportFactory;

        public User(string username, IAccount account, IPurchaseReportFactory reportFactory)
        {
            Username = username;
            this.account = account;
            this.reportFactory = reportFactory;
        }

        public decimal Balance => account.Balance;

        public string Username { get; }

        public void Deposit(decimal amount)
        {
            account.Deposit(amount);
        }

        public IPurchaseReport Purchase(IProduct product)
        {
            return account.TryWithdraw(product.Price)
                .Select(trans => new Receipt(Username, product.Name, product.Price))
                .DefaultIfEmpty(NotEnoughMoneyReport(product.Name, product.Price)).Single();
        }

        private IPurchaseReport NotEnoughMoneyReport(string productName, decimal price)
        {
            return reportFactory.CreateNotEnoughMoney(Username, productName, price);
        }
    }
}