﻿using System.Collections.Generic;
using System.Linq;
using NullReferencesDemo.Application.Interfaces;
using NullReferencesDemo.Common;
using NullReferencesDemo.Domain.Interfaces;
using NullReferencesDemo.Presentation.Interfaces;

namespace NullReferencesDemo.Domain.Implementation
{
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
            IUser user = new User(username, userAccount, reportFactory);

            userRepository.Add(user);
        }

        public void Deposit(string username, decimal amount)
        {
            userRepository.Find(username).ForEach(user => user.Deposit(amount));
        }

        public IEnumerable<StockItem> GetAvailableItems()
        {
            return productRepository.GetAll().Select(product => new StockItem(product.Name, product.Price));
        }

        public decimal GetBalance(string username)
        {
            return userRepository.Find(username).Select(user => user.Balance).DefaultIfEmpty(0).Single();
        }

        public bool IsRegistered(string username)
        {
            return userRepository.Find(username).Any();
        }

        public IPurchaseReport Purchase(string username, string itemName)
        {
            return productRepository.TryFind(itemName).Select(product => Purchase(username, product))
                .DefaultIfEmpty(reportFactory.CreateProductNotFound(username, itemName)).Single();
        }

        private IPurchaseReport Purchase(string username, IProduct product)
        {
            return userRepository.Find(username).Select(user => user.Purchase(product))
                .LazyDefaultIfEmpty(() => reportFactory.CreateNotRegistered(username)).Single();
        }
    }
}