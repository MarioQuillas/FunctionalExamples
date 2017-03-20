using System;
using NullReferencesDemo.Domain.Interfaces;
using NullReferencesDemo.Common;

namespace NullReferencesDemo.Domain.Implementation
{
    public class DebitAccount: AccountBase
    {

        public override MoneyTransaction Deposit(decimal amount)
        {

            if (amount <= 0)
                throw new ArgumentException("Amount to deposit must be positive.", nameof(amount));

            MoneyTransaction trans = new MoneyTransaction(amount);

            base.RegisterTransaction(trans);
            
            return trans;
        
        }

        public override Option<MoneyTransaction> TryWithdraw(decimal amount)
        {

            if (amount <= 0)
                throw new ArgumentException("Amount to withdraw must be positive.", nameof(amount));

            if (this.Balance < amount)
                return Option<MoneyTransaction>.CreateEmpty();

            MoneyTransaction trans = new MoneyTransaction(-amount);
            base.RegisterTransaction(trans);

            return Option<MoneyTransaction>.Create(trans);

        }
    }
}
