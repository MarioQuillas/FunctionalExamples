namespace DddInPractice.Logic.Management
{
    using DddInPractice.Logic.Atms;
    using DddInPractice.Logic.Common;
    using DddInPractice.Logic.SharedKernel;
    using DddInPractice.Logic.SnackMachines;

    public class HeadOffice : AggregateRoot
    {
        public virtual decimal Balance { get; protected set; }

        public virtual Money Cash { get; protected set; } = Money.None;

        public virtual void ChangeBalance(decimal delta)
        {
            this.Balance += delta;
        }

        public virtual void LoadCashToAtm(Atm atm)
        {
            atm.LoadMoney(this.Cash);
            this.Cash = Money.None;
        }

        public virtual void UnloadCashFromSnackMachine(SnackMachine snackMachine)
        {
            Money money = snackMachine.UnloadMoney();
            this.Cash += money;
        }
    }
}