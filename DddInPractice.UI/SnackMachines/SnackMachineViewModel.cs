namespace DddInPractice.UI.SnackMachines
{
    using System.Collections.Generic;
    using System.Linq;

    using DddInPractice.Logic.SharedKernel;
    using DddInPractice.Logic.SnackMachines;
    using DddInPractice.UI.Common;

    public class SnackMachineViewModel : ViewModel
    {
        private readonly SnackMachineRepository _repository;

        private readonly SnackMachine _snackMachine;

        private string _message = string.Empty;

        public SnackMachineViewModel(SnackMachine snackMachine)
        {
            this._snackMachine = snackMachine;
            this._repository = new SnackMachineRepository();

            this.InsertCentCommand = new Command(() => this.InsertMoney(Money.Cent));
            this.InsertTenCentCommand = new Command(() => this.InsertMoney(Money.TenCent));
            this.InsertQuarterCommand = new Command(() => this.InsertMoney(Money.Quarter));
            this.InsertDollarCommand = new Command(() => this.InsertMoney(Money.Dollar));
            this.InsertFiveDollarCommand = new Command(() => this.InsertMoney(Money.FiveDollar));
            this.InsertTwentyDollarCommand = new Command(() => this.InsertMoney(Money.TwentyDollar));
            this.ReturnMoneyCommand = new Command(() => this.ReturnMoney());
            this.BuySnackCommand = new Command<string>(this.BuySnack);
        }

        public Command<string> BuySnackCommand { get; private set; }

        public override string Caption => "Snack Machine";

        public Command InsertCentCommand { get; private set; }

        public Command InsertDollarCommand { get; private set; }

        public Command InsertFiveDollarCommand { get; private set; }

        public Command InsertQuarterCommand { get; private set; }

        public Command InsertTenCentCommand { get; private set; }

        public Command InsertTwentyDollarCommand { get; private set; }

        public string Message
        {
            get
            {
                return this._message;
            }

            private set
            {
                this._message = value;
                this.Notify();
            }
        }

        public Money MoneyInside => this._snackMachine.MoneyInside;

        public string MoneyInTransaction => this._snackMachine.MoneyInTransaction.ToString();

        public IReadOnlyList<SnackPileViewModel> Piles
        {
            get
            {
                return this._snackMachine.GetAllSnackPiles().Select(x => new SnackPileViewModel(x)).ToList();
            }
        }

        public Command ReturnMoneyCommand { get; private set; }

        private void BuySnack(string positionString)
        {
            int position = int.Parse(positionString);

            string error = this._snackMachine.CanBuySnack(position);
            if (error != string.Empty)
            {
                this.NotifyClient(error);
                return;
            }

            this._snackMachine.BuySnack(position);
            this._repository.Save(this._snackMachine);
            this.NotifyClient("You have bought a snack");
        }

        private void InsertMoney(Money coinOrNote)
        {
            this._snackMachine.InsertMoney(coinOrNote);
            this.NotifyClient("You have inserted: " + coinOrNote);
        }

        private void NotifyClient(string message)
        {
            this.Message = message;
            this.Notify(nameof(this.MoneyInTransaction));
            this.Notify(nameof(this.MoneyInside));
            this.Notify(nameof(this.Piles));
        }

        private void ReturnMoney()
        {
            this._snackMachine.ReturnMoney();
            this.NotifyClient("Money was returned");
        }
    }
}