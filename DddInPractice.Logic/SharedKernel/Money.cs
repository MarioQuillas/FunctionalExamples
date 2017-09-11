namespace DddInPractice.Logic.SharedKernel
{
    using System;

    using DddInPractice.Logic.Common;

    public sealed class Money : ValueObject<Money>
    {
        public static readonly Money Cent = new Money(1, 0, 0, 0, 0, 0);

        public static readonly Money Dollar = new Money(0, 0, 0, 1, 0, 0);

        public static readonly Money FiveDollar = new Money(0, 0, 0, 0, 1, 0);

        public static readonly Money None = new Money(0, 0, 0, 0, 0, 0);

        public static readonly Money Quarter = new Money(0, 0, 1, 0, 0, 0);

        public static readonly Money TenCent = new Money(0, 1, 0, 0, 0, 0);

        public static readonly Money TwentyDollar = new Money(0, 0, 0, 0, 0, 1);

        public Money(
            int oneCentCount,
            int tenCentCount,
            int quarterCount,
            int oneDollarCount,
            int fiveDollarCount,
            int twentyDollarCount)
            : this()
        {
            if (oneCentCount < 0) throw new InvalidOperationException();
            if (tenCentCount < 0) throw new InvalidOperationException();
            if (quarterCount < 0) throw new InvalidOperationException();
            if (oneDollarCount < 0) throw new InvalidOperationException();
            if (fiveDollarCount < 0) throw new InvalidOperationException();
            if (twentyDollarCount < 0) throw new InvalidOperationException();

            this.OneCentCount = oneCentCount;
            this.TenCentCount = tenCentCount;
            this.QuarterCount = quarterCount;
            this.OneDollarCount = oneDollarCount;
            this.FiveDollarCount = fiveDollarCount;
            this.TwentyDollarCount = twentyDollarCount;
        }

        private Money()
        {
        }

        public decimal Amount => this.OneCentCount * 0.01m + this.TenCentCount * 0.10m + this.QuarterCount * 0.25m
                                 + this.OneDollarCount + this.FiveDollarCount * 5 + this.TwentyDollarCount * 20;

        public int FiveDollarCount { get; }

        public int OneCentCount { get; }

        public int OneDollarCount { get; }

        public int QuarterCount { get; }

        public int TenCentCount { get; }

        public int TwentyDollarCount { get; }

        public static Money operator +(Money money1, Money money2)
        {
            Money sum = new Money(
                money1.OneCentCount + money2.OneCentCount,
                money1.TenCentCount + money2.TenCentCount,
                money1.QuarterCount + money2.QuarterCount,
                money1.OneDollarCount + money2.OneDollarCount,
                money1.FiveDollarCount + money2.FiveDollarCount,
                money1.TwentyDollarCount + money2.TwentyDollarCount);

            return sum;
        }

        public static Money operator *(Money money1, int multiplier)
        {
            Money result = new Money(
                money1.OneCentCount * multiplier,
                money1.TenCentCount * multiplier,
                money1.QuarterCount * multiplier,
                money1.OneDollarCount * multiplier,
                money1.FiveDollarCount * multiplier,
                money1.TwentyDollarCount * multiplier);

            return result;
        }

        public static Money operator -(Money money1, Money money2)
        {
            return new Money(
                money1.OneCentCount - money2.OneCentCount,
                money1.TenCentCount - money2.TenCentCount,
                money1.QuarterCount - money2.QuarterCount,
                money1.OneDollarCount - money2.OneDollarCount,
                money1.FiveDollarCount - money2.FiveDollarCount,
                money1.TwentyDollarCount - money2.TwentyDollarCount);
        }

        public Money Allocate(decimal amount)
        {
            if (!this.CanAllocate(amount)) throw new InvalidOperationException();

            return this.AllocateCore(amount);
        }

        public bool CanAllocate(decimal amount)
        {
            Money money = this.AllocateCore(amount);
            return money.Amount == amount;
        }

        public override string ToString()
        {
            if (this.Amount < 1) return "¢" + (this.Amount * 100).ToString("0");

            return "$" + this.Amount.ToString("0.00");
        }

        protected override bool EqualsCore(Money other)
        {
            return this.OneCentCount == other.OneCentCount && this.TenCentCount == other.TenCentCount
                   && this.QuarterCount == other.QuarterCount && this.OneDollarCount == other.OneDollarCount
                   && this.FiveDollarCount == other.FiveDollarCount
                   && this.TwentyDollarCount == other.TwentyDollarCount;
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                int hashCode = this.OneCentCount;
                hashCode = (hashCode * 397) ^ this.TenCentCount;
                hashCode = (hashCode * 397) ^ this.QuarterCount;
                hashCode = (hashCode * 397) ^ this.OneDollarCount;
                hashCode = (hashCode * 397) ^ this.FiveDollarCount;
                hashCode = (hashCode * 397) ^ this.TwentyDollarCount;
                return hashCode;
            }
        }

        private Money AllocateCore(decimal amount)
        {
            int twentyDollarCount = Math.Min((int)(amount / 20), this.TwentyDollarCount);
            amount = amount - twentyDollarCount * 20;

            int fiveDollarCount = Math.Min((int)(amount / 5), this.FiveDollarCount);
            amount = amount - fiveDollarCount * 5;

            int oneDollarCount = Math.Min((int)amount, this.OneDollarCount);
            amount = amount - oneDollarCount;

            int quarterCount = Math.Min((int)(amount / 0.25m), this.QuarterCount);
            amount = amount - quarterCount * 0.25m;

            int tenCentCount = Math.Min((int)(amount / 0.1m), this.TenCentCount);
            amount = amount - tenCentCount * 0.1m;

            int oneCentCount = Math.Min((int)(amount / 0.01m), this.OneCentCount);

            return new Money(
                oneCentCount,
                tenCentCount,
                quarterCount,
                oneDollarCount,
                fiveDollarCount,
                twentyDollarCount);
        }
    }
}