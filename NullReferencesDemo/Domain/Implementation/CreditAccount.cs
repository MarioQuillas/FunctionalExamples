namespace NullReferencesDemo.Domain.Implementation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using NullReferencesDemo.Common;
    using NullReferencesDemo.Domain.Interfaces;

    public class CreditAccount : AccountBase
    {
        private readonly IList<MoneyTransaction> pendingTransactions = new List<MoneyTransaction>();

        private readonly ITransactionSelector pendingTransactionSelectionStrategy;

        public CreditAccount(ITransactionSelector transactionSelectionStrategy)
        {
            if (transactionSelectionStrategy == null)
                throw new ArgumentNullException(nameof(transactionSelectionStrategy));

            this.pendingTransactionSelectionStrategy = transactionSelectionStrategy;
        }

        public override decimal Balance
        {
            get
            {
                return base.Balance + this.pendingTransactions.Sum(trans => trans.Amount);
            }
        }

        public override MoneyTransaction Deposit(decimal amount)
        {
            if (amount <= 0) throw new ArgumentException("Amount to deposit must be positive.");

            MoneyTransaction transaction = new MoneyTransaction(amount);
            this.RegisterTransaction(transaction);

            this.ProcessPendingWithdrawals();

            return transaction;
        }

        public override Option<MoneyTransaction> TryWithdraw(decimal amount)
        {
            if (amount <= 0) throw new ArgumentException("Amount to withdraw must be positive.", nameof(amount));

            MoneyTransaction transaction = new MoneyTransaction(-amount);

            this.pendingTransactions.Add(transaction);
            this.ProcessPendingWithdrawals();

            return Option<MoneyTransaction>.Create(transaction);
        }

        private void ProcessPendingWithdrawal(Option<MoneyTransaction> option)
        {
            if (!option.Any()) return;

            MoneyTransaction transaction = option.Single();

            this.RegisterTransaction(transaction);
            this.pendingTransactions.Remove(transaction);
        }

        private void ProcessPendingWithdrawals()
        {
            Option<MoneyTransaction> option = Option<MoneyTransaction>.CreateEmpty();

            do
            {
                option = this.TrySelectPendingTransaction();
                this.ProcessPendingWithdrawal(option);
            }
            while (option.Any());
        }

        private Option<MoneyTransaction> TrySelectPendingTransaction()
        {
            return this.pendingTransactionSelectionStrategy.TrySelectOne(this.pendingTransactions, base.Balance);
        }
    }
}