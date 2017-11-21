using System;
using NullReferencesDemo.Common;
using NullReferencesDemo.Domain.Interfaces;

namespace NullReferencesDemo.Domain.Implementation
{
    public class DebitAccount : AccountBase
    {
        public override MoneyTransaction Deposit(decimal amount)
        {
            if (amount <= 0) throw new ArgumentException("Amount to deposit must be positive.", nameof(amount));

            var trans = new MoneyTransaction(amount);

            RegisterTransaction(trans);

            return trans;
        }

        public override Option<MoneyTransaction> TryWithdraw(decimal amount)
        {
            if (amount <= 0) throw new ArgumentException("Amount to withdraw must be positive.", nameof(amount));

            if (Balance < amount) return Option<MoneyTransaction>.CreateEmpty();

            var trans = new MoneyTransaction(-amount);
            RegisterTransaction(trans);

            return Option<MoneyTransaction>.Create(trans);
        }
    }
}