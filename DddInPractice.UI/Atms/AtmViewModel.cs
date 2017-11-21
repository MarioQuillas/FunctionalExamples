using DddInPractice.Logic.Atms;
using DddInPractice.Logic.SharedKernel;
using DddInPractice.UI.Common;

namespace DddInPractice.UI.Atms
{
    public class AtmViewModel : ViewModel
    {
        private readonly Atm _atm;

        private readonly PaymentGateway _paymentGateway;

        private readonly AtmRepository _repository;

        private string _message;

        public AtmViewModel(Atm atm)
        {
            _atm = atm;
            _repository = new AtmRepository();
            _paymentGateway = new PaymentGateway();

            TakeMoneyCommand = new Command<decimal>(x => x > 0, TakeMoney);
        }

        public override string Caption => "ATM";

        public string Message
        {
            get => _message;

            private set
            {
                _message = value;
                Notify();
            }
        }

        public string MoneyCharged => _atm.MoneyCharged.ToString("C2");

        public Money MoneyInside => _atm.MoneyInside;

        public Command<decimal> TakeMoneyCommand { get; }

        private void NotifyClient(string message)
        {
            Message = message;
            Notify(nameof(MoneyInside));
            Notify(nameof(MoneyCharged));
        }

        private void TakeMoney(decimal amount)
        {
            var error = _atm.CanTakeMoney(amount);
            if (error != string.Empty)
            {
                NotifyClient(error);
                return;
            }

            var amountWithCommission = _atm.CaluculateAmountWithCommission(amount);
            _paymentGateway.ChargePayment(amountWithCommission);
            _atm.TakeMoney(amount);
            _repository.Save(_atm);

            NotifyClient("You have taken " + amount.ToString("C2"));
        }
    }
}