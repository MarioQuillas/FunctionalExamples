using System;
using System.Collections.Generic;
using System.Linq;
using NullReferencesDemo.Common;
using NullReferencesDemo.Domain.Interfaces;

namespace NullReferencesDemo.Domain.Implementation
{
    public class CreditAccount : AccountBase
    {
        private readonly IList<MoneyTransaction> pendingTransactions = new List<MoneyTransaction>();

        private readonly ITransactionSelector pendingTransactionSelectionStrategy;

        public CreditAccount(ITransactionSelector transactionSelectionStrategy)
        {
            if (transactionSelectionStrategy == null)
                throw new ArgumentNullException(nameof(transactionSelectionStrategy));

            pendingTransactionSelectionStrategy = transactionSelectionStrategy;
        }

        public override decimal Balance
        {
            get { return base.Balance + pendingTransactions.Sum(trans => trans.Amount); }
        }

        public override MoneyTransaction Deposit(decimal amount)
        {
            if (amount <= 0) throw new ArgumentException("Amount to deposit must be positive.");

            var transaction = new MoneyTransaction(amount);
            RegisterTransaction(transaction);

            ProcessPendingWithdrawals();

            return transaction;
        }

        public override Option<MoneyTransaction> TryWithdraw(decimal amount)
        {
            if (amount <= 0) throw new ArgumentException("Amount to withdraw must be positive.", nameof(amount));

            var transaction = new MoneyTransaction(-amount);

            pendingTransactions.Add(transaction);
            ProcessPendingWithdrawals();

            return Option<MoneyTransaction>.Create(transaction);
        }

        private void ProcessPendingWithdrawal(Option<MoneyTransaction> option)
        {
            if (!option.Any()) return;

            var transaction = option.Single();

            RegisterTransaction(transaction);
            pendingTransactions.Remove(transaction);
        }

        private void ProcessPendingWithdrawals()
        {
            var option = Option<MoneyTransaction>.CreateEmpty();

            do
            {
                option = TrySelectPendingTransaction();
                ProcessPendingWithdrawal(option);
            } while (option.Any());
        }

        private Option<MoneyTransaction> TrySelectPendingTransaction()
        {
            return pendingTransactionSelectionStrategy.TrySelectOne(pendingTransactions, base.Balance);
        }
    }
}