namespace DddInPractice.Logic.SnackMachines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using DddInPractice.Logic.Common;
    using DddInPractice.Logic.SharedKernel;

    public class SnackMachine : AggregateRoot
    {
        public SnackMachine()
        {
            this.MoneyInside = Money.None;
            this.MoneyInTransaction = 0;
            this.Slots = new List<Slot> { new Slot(this, 1), new Slot(this, 2), new Slot(this, 3) };
        }

        public virtual Money MoneyInside { get; protected set; }

        public virtual decimal MoneyInTransaction { get; protected set; }

        protected virtual IList<Slot> Slots { get; }

        public virtual void BuySnack(int position)
        {
            if (this.CanBuySnack(position) != string.Empty) throw new InvalidOperationException();

            Slot slot = this.GetSlot(position);
            slot.SnackPile = slot.SnackPile.SubtractOne();

            Money change = this.MoneyInside.Allocate(this.MoneyInTransaction - slot.SnackPile.Price);
            this.MoneyInside -= change;
            this.MoneyInTransaction = 0;
        }

        public virtual string CanBuySnack(int position)
        {
            SnackPile snackPile = this.GetSnackPile(position);

            if (snackPile.Quantity == 0) return "The snack pile is empty";

            if (this.MoneyInTransaction < snackPile.Price) return "Not enough money";

            if (!this.MoneyInside.CanAllocate(this.MoneyInTransaction - snackPile.Price)) return "Not enough change";

            return string.Empty;
        }

        public virtual IReadOnlyList<SnackPile> GetAllSnackPiles()
        {
            return this.Slots.OrderBy(x => x.Position).Select(x => x.SnackPile).ToList();
        }

        public virtual SnackPile GetSnackPile(int position)
        {
            return this.GetSlot(position).SnackPile;
        }

        public virtual void InsertMoney(Money money)
        {
            Money[] coinsAndNotes =
                { Money.Cent, Money.TenCent, Money.Quarter, Money.Dollar, Money.FiveDollar, Money.TwentyDollar };
            if (!coinsAndNotes.Contains(money)) throw new InvalidOperationException();

            this.MoneyInTransaction += money.Amount;
            this.MoneyInside += money;
        }

        public virtual void LoadMoney(Money money)
        {
            this.MoneyInside += money;
        }

        public virtual void LoadSnacks(int position, SnackPile snackPile)
        {
            Slot slot = this.GetSlot(position);
            slot.SnackPile = snackPile;
        }

        public virtual void ReturnMoney()
        {
            Money moneyToReturn = this.MoneyInside.Allocate(this.MoneyInTransaction);
            this.MoneyInside -= moneyToReturn;
            this.MoneyInTransaction = 0;
        }

        public virtual Money UnloadMoney()
        {
            if (this.MoneyInTransaction > 0) throw new InvalidOperationException();

            Money money = this.MoneyInside;
            this.MoneyInside = Money.None;
            return money;
        }

        private Slot GetSlot(int position)
        {
            return this.Slots.Single(x => x.Position == position);
        }
    }
}