using System.Collections.Generic;
using System.Linq;
using DddInPractice.Logic.SharedKernel;
using DddInPractice.Logic.SnackMachines;
using DddInPractice.UI.Common;

namespace DddInPractice.UI.SnackMachines
{
    public class SnackMachineViewModel : ViewModel
    {
        private readonly SnackMachineRepository _repository;

        private readonly SnackMachine _snackMachine;

        private string _message = string.Empty;

        public SnackMachineViewModel(SnackMachine snackMachine)
        {
            _snackMachine = snackMachine;
            _repository = new SnackMachineRepository();

            InsertCentCommand = new Command(() => InsertMoney(Money.Cent));
            InsertTenCentCommand = new Command(() => InsertMoney(Money.TenCent));
            InsertQuarterCommand = new Command(() => InsertMoney(Money.Quarter));
            InsertDollarCommand = new Command(() => InsertMoney(Money.Dollar));
            InsertFiveDollarCommand = new Command(() => InsertMoney(Money.FiveDollar));
            InsertTwentyDollarCommand = new Command(() => InsertMoney(Money.TwentyDollar));
            ReturnMoneyCommand = new Command(() => ReturnMoney());
            BuySnackCommand = new Command<string>(BuySnack);
        }

        public Command<string> BuySnackCommand { get; }

        public override string Caption => "Snack Machine";

        public Command InsertCentCommand { get; }

        public Command InsertDollarCommand { get; }

        public Command InsertFiveDollarCommand { get; }

        public Command InsertQuarterCommand { get; }

        public Command InsertTenCentCommand { get; }

        public Command InsertTwentyDollarCommand { get; }

        public string Message
        {
            get => _message;

            private set
            {
                _message = value;
                Notify();
            }
        }

        public Money MoneyInside => _snackMachine.MoneyInside;

        public string MoneyInTransaction => _snackMachine.MoneyInTransaction.ToString();

        public IReadOnlyList<SnackPileViewModel> Piles
        {
            get { return _snackMachine.GetAllSnackPiles().Select(x => new SnackPileViewModel(x)).ToList(); }
        }

        public Command ReturnMoneyCommand { get; }

        private void BuySnack(string positionString)
        {
            var position = int.Parse(positionString);

            var error = _snackMachine.CanBuySnack(position);
            if (error != string.Empty)
            {
                NotifyClient(error);
                return;
            }

            _snackMachine.BuySnack(position);
            _repository.Save(_snackMachine);
            NotifyClient("You have bought a snack");
        }

        private void InsertMoney(Money coinOrNote)
        {
            _snackMachine.InsertMoney(coinOrNote);
            NotifyClient("You have inserted: " + coinOrNote);
        }

        private void NotifyClient(string message)
        {
            Message = message;
            Notify(nameof(MoneyInTransaction));
            Notify(nameof(MoneyInside));
            Notify(nameof(Piles));
        }

        private void ReturnMoney()
        {
            _snackMachine.ReturnMoney();
            NotifyClient("Money was returned");
        }
    }
}