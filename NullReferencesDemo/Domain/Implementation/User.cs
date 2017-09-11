namespace NullReferencesDemo.Domain.Implementation
{
    using System.Linq;

    using NullReferencesDemo.Domain.Interfaces;
    using NullReferencesDemo.Presentation.Interfaces;
    using NullReferencesDemo.Presentation.PurchaseReports;

    internal class User : IUser
    {
        private readonly IAccount account;

        private readonly IPurchaseReportFactory reportFactory;

        public User(string username, IAccount account, IPurchaseReportFactory reportFactory)
        {
            this.Username = username;
            this.account = account;
            this.reportFactory = reportFactory;
        }

        public decimal Balance => this.account.Balance;

        public string Username { get; private set; }

        public void Deposit(decimal amount)
        {
            this.account.Deposit(amount);
        }

        public IPurchaseReport Purchase(IProduct product)
        {
            return this.account.TryWithdraw(product.Price)
                .Select(trans => new Receipt(this.Username, product.Name, product.Price))
                .DefaultIfEmpty(this.NotEnoughMoneyReport(product.Name, product.Price)).Single();
        }

        private IPurchaseReport NotEnoughMoneyReport(string productName, decimal price)
        {
            return this.reportFactory.CreateNotEnoughMoney(this.Username, productName, price);
        }
    }
}