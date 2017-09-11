namespace NullReferencesDemo.Domain.Implementation
{
    using System.Collections.Generic;
    using System.Linq;

    using NullReferencesDemo.Common;
    using NullReferencesDemo.Domain.Interfaces;

    public abstract class AccountBase : IAccount
    {
        private readonly IList<MoneyTransaction> registeredTransactions = new List<MoneyTransaction>();

        public virtual decimal Balance
        {
            get
            {
                return this.registeredTransactions.Sum(trans => trans.Amount);
            }
        }

        public abstract MoneyTransaction Deposit(decimal amount);

        public abstract Option<MoneyTransaction> TryWithdraw(decimal amount);

        protected void RegisterTransaction(MoneyTransaction trans)
        {
            this.registeredTransactions.Add(trans);
        }
    }
}