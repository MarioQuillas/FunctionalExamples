using DddInPractice.Logic.Common;

namespace DddInPractice.Logic.SnackMachines
{
    public class Slot : Entity
    {
        public Slot(SnackMachine snackMachine, int position)
            : this()
        {
            SnackMachine = snackMachine;
            Position = position;
            SnackPile = SnackPile.Empty;
        }

        protected Slot()
        {
        }

        public virtual int Position { get; }

        public virtual SnackMachine SnackMachine { get; }

        public virtual SnackPile SnackPile { get; set; }
    }
}