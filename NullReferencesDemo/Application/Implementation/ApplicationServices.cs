namespace NullReferencesDemo.Application.Implementation
{
    using System;
    using System.Collections.Generic;

    using NullReferencesDemo.Application.Interfaces;
    using NullReferencesDemo.Presentation.Interfaces;

    public class ApplicationServices : IApplicationServices
    {
        private readonly IDomainServices domainServices;

        private readonly IPurchaseReportFactory reportFactory;

        private string loggedInUsername;

        public ApplicationServices(IDomainServices domainServices, IPurchaseReportFactory reportFactory)
        {
            this.domainServices = domainServices;
            this.loggedInUsername = string.Empty;
            this.reportFactory = reportFactory;
        }

        public bool IsUserLoggedIn
        {
            get
            {
                return !string.IsNullOrEmpty(this.loggedInUsername);
            }
        }

        public decimal LoggedInUserBalance
        {
            get
            {
                this.AssertUserLoggedIn();
                return this.domainServices.GetBalance(this.loggedInUsername);
            }
        }

        public string LoggedInUsername
        {
            get
            {
                this.AssertUserLoggedIn();
                return this.loggedInUsername;
            }
        }

        public void Deposit(decimal amount)
        {
            this.AssertUserLoggedIn();
            this.domainServices.Deposit(this.loggedInUsername, amount);
        }

        public IEnumerable<StockItem> GetAvailableItems()
        {
            return this.domainServices.GetAvailableItems();
        }

        public bool Login(string username)
        {
            bool loggedIn = this.domainServices.IsRegistered(username);

            if (loggedIn) this.loggedInUsername = username;

            return loggedIn;
        }

        public void Logout()
        {
            this.loggedInUsername = string.Empty;
        }

        public IPurchaseReport Purchase(string itemName)
        {
            if (!this.IsUserLoggedIn) return this.reportFactory.CreateNotSignedIn();

            return this.domainServices.Purchase(this.loggedInUsername, itemName);
        }

        public void RegisterUser(string username)
        {
            this.domainServices.CreateUser(username);
        }

        private void AssertUserLoggedIn()
        {
            if (!this.IsUserLoggedIn) throw new InvalidOperationException("No user logged in.");
        }
    }
}