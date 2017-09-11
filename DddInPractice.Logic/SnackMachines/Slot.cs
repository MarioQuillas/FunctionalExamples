namespace DddInPractice.Logic.SnackMachines
{
    using DddInPractice.Logic.Common;

    public class Slot : Entity
    {
        public Slot(SnackMachine snackMachine, int position)
            : this()
        {
            this.SnackMachine = snackMachine;
            this.Position = position;
            this.SnackPile = SnackPile.Empty;
        }

        protected Slot()
        {
        }

        public virtual int Position { get; }

        public virtual SnackMachine SnackMachine { get; }

        public virtual SnackPile SnackPile { get; set; }
    }
}