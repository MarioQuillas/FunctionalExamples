namespace DddInPractice.Logic.SnackMachines
{
    using System;

    using DddInPractice.Logic.Common;

    public sealed class SnackPile : ValueObject<SnackPile>
    {
        public static readonly SnackPile Empty = new SnackPile(Snack.None, 0, 0m);

        public SnackPile(Snack snack, int quantity, decimal price)
            : this()
        {
            if (quantity < 0) throw new InvalidOperationException();
            if (price < 0) throw new InvalidOperationException();
            if (price % 0.01m > 0) throw new InvalidOperationException();

            this.Snack = snack;
            this.Quantity = quantity;
            this.Price = price;
        }

        private SnackPile()
        {
        }

        public decimal Price { get; }

        public int Quantity { get; }

        public Snack Snack { get; }

        public SnackPile SubtractOne()
        {
            return new SnackPile(this.Snack, this.Quantity - 1, this.Price);
        }

        protected override bool EqualsCore(SnackPile other)
        {
            return this.Snack == other.Snack && this.Quantity == other.Quantity && this.Price == other.Price;
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                int hashCode = this.Snack.GetHashCode();
                hashCode = (hashCode * 397) ^ this.Quantity;
                hashCode = (hashCode * 397) ^ this.Price.GetHashCode();
                return hashCode;
            }
        }
    }
}