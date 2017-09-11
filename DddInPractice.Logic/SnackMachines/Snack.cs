namespace DddInPractice.Logic.SnackMachines
{
    using DddInPractice.Logic.Common;

    public class Snack : AggregateRoot
    {
        public static readonly Snack Chocolate = new Snack(1, "Chocolate");

        public static readonly Snack Gum = new Snack(3, "Gum");

        public static readonly Snack None = new Snack(0, "None");

        public static readonly Snack Soda = new Snack(2, "Soda");

        protected Snack()
        {
        }

        private Snack(long id, string name)
            : this()
        {
            this.Id = id;
            this.Name = name;
        }

        public virtual string Name { get; }
    }
}