﻿namespace NullReferencesDemo.Domain.Implementation
{
    using System.Collections.Generic;
    using System.Linq;

    using NullReferencesDemo.Application.Interfaces;
    using NullReferencesDemo.Common;
    using NullReferencesDemo.Domain.Interfaces;
    using NullReferencesDemo.Presentation.Interfaces;

    public class DomainServices : IDomainServices
    {
        private readonly IProductRepository productRepository;

        private readonly IPurchaseReportFactory reportFactory;

        private readonly IUserRepository userRepository;

        public DomainServices(
            IUserRepository userRepository,
            IProductRepository productRepository,
            IPurchaseReportFactory reportFactory)
        {
            this.userRepository = userRepository;
            this.productRepository = productRepository;
            this.reportFactory = reportFactory;
        }

        public void CreateUser(string username)
        {
            IAccount userAccount = new DebitAccount();
            IUser user = new User(username, userAccount, this.reportFactory);

            this.userRepository.Add(user);
        }

        public void Deposit(string username, decimal amount)
        {
            this.userRepository.Find(username).ForEach(user => user.Deposit(amount));
        }

        public IEnumerable<StockItem> GetAvailableItems()
        {
            return this.productRepository.GetAll().Select(product => new StockItem(product.Name, product.Price));
        }

        public decimal GetBalance(string username)
        {
            return this.userRepository.Find(username).Select(user => user.Balance).DefaultIfEmpty(0).Single();
        }

        public bool IsRegistered(string username)
        {
            return this.userRepository.Find(username).Any();
        }

        public IPurchaseReport Purchase(string username, string itemName)
        {
            return this.productRepository.TryFind(itemName).Select(product => this.Purchase(username, product))
                .DefaultIfEmpty(this.reportFactory.CreateProductNotFound(username, itemName)).Single();
        }

        private IPurchaseReport Purchase(string username, IProduct product)
        {
            return this.userRepository.Find(username).Select(user => user.Purchase(product))
                .LazyDefaultIfEmpty(() => this.reportFactory.CreateNotRegistered(username)).Single();
        }
    }
}