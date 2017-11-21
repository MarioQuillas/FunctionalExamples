using System;
using System.Collections.Generic;
using NullReferencesDemo.Application.Interfaces;
using NullReferencesDemo.Presentation.Interfaces;

namespace NullReferencesDemo.Application.Implementation
{
    public class ApplicationServices : IApplicationServices
    {
        private readonly IDomainServices domainServices;

        private readonly IPurchaseReportFactory reportFactory;

        private string loggedInUsername;

        public ApplicationServices(IDomainServices domainServices, IPurchaseReportFactory reportFactory)
        {
            this.domainServices = domainServices;
            loggedInUsername = string.Empty;
            this.reportFactory = reportFactory;
        }

        public bool IsUserLoggedIn => !string.IsNullOrEmpty(loggedInUsername);

        public decimal LoggedInUserBalance
        {
            get
            {
                AssertUserLoggedIn();
                return domainServices.GetBalance(loggedInUsername);
            }
        }

        public string LoggedInUsername
        {
            get
            {
                AssertUserLoggedIn();
                return loggedInUsername;
            }
        }

        public void Deposit(decimal amount)
        {
            AssertUserLoggedIn();
            domainServices.Deposit(loggedInUsername, amount);
        }

        public IEnumerable<StockItem> GetAvailableItems()
        {
            return domainServices.GetAvailableItems();
        }

        public bool Login(string username)
        {
            var loggedIn = domainServices.IsRegistered(username);

            if (loggedIn) loggedInUsername = username;

            return loggedIn;
        }

        public void Logout()
        {
            loggedInUsername = string.Empty;
        }

        public IPurchaseReport Purchase(string itemName)
        {
            if (!IsUserLoggedIn) return reportFactory.CreateNotSignedIn();

            return domainServices.Purchase(loggedInUsername, itemName);
        }

        public void RegisterUser(string username)
        {
            domainServices.CreateUser(username);
        }

        private void AssertUserLoggedIn()
        {
            if (!IsUserLoggedIn) throw new InvalidOperationException("No user logged in.");
        }
    }
}