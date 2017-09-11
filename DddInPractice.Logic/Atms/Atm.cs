using static DddInPractice.Logic.SharedKernel.Money;

namespace DddInPractice.Logic.Atms
{
    using System;

    using DddInPractice.Logic.Common;
    using DddInPractice.Logic.SharedKernel;

    public class Atm : AggregateRoot
    {
        private const decimal CommissionRate = 0.01m;

        public virtual decimal MoneyCharged { get; protected set; }

        public virtual Money MoneyInside { get; protected set; } = None;

        public virtual decimal CaluculateAmountWithCommission(decimal amount)
        {
            decimal commission = amount * CommissionRate;
            decimal lessThanCent = commission % 0.01m;
            if (lessThanCent > 0)
            {
                commission = commission - lessThanCent + 0.01m;
            }

            return amount + commission;
        }

        public virtual string CanTakeMoney(decimal amount)
        {
            if (amount <= 0m) return "Invalid amount";

            if (this.MoneyInside.Amount < amount) return "Not enough money";

            if (!this.MoneyInside.CanAllocate(amount)) return "Not enough change";

            return string.Empty;
        }

        public virtual void LoadMoney(Money money)
        {
            this.MoneyInside += money;
        }

        public virtual void TakeMoney(decimal amount)
        {
            if (this.CanTakeMoney(amount) != string.Empty) throw new InvalidOperationException();

            Money output = this.MoneyInside.Allocate(amount);
            this.MoneyInside -= output;

            decimal amountWithCommission = this.CaluculateAmountWithCommission(amount);
            this.MoneyCharged += amountWithCommission;

            this.AddDomainEvent(new BalanceChangedEvent(amountWithCommission));
        }
    }
}