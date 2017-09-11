namespace DddInPractice.UI.Atms
{
    using DddInPractice.Logic.Atms;
    using DddInPractice.Logic.SharedKernel;
    using DddInPractice.UI.Common;

    public class AtmViewModel : ViewModel
    {
        private readonly Atm _atm;

        private readonly PaymentGateway _paymentGateway;

        private readonly AtmRepository _repository;

        private string _message;

        public AtmViewModel(Atm atm)
        {
            this._atm = atm;
            this._repository = new AtmRepository();
            this._paymentGateway = new PaymentGateway();

            this.TakeMoneyCommand = new Command<decimal>(x => x > 0, this.TakeMoney);
        }

        public override string Caption => "ATM";

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

        public string MoneyCharged => this._atm.MoneyCharged.ToString("C2");

        public Money MoneyInside => this._atm.MoneyInside;

        public Command<decimal> TakeMoneyCommand { get; private set; }

        private void NotifyClient(string message)
        {
            this.Message = message;
            this.Notify(nameof(this.MoneyInside));
            this.Notify(nameof(this.MoneyCharged));
        }

        private void TakeMoney(decimal amount)
        {
            string error = this._atm.CanTakeMoney(amount);
            if (error != string.Empty)
            {
                this.NotifyClient(error);
                return;
            }

            decimal amountWithCommission = this._atm.CaluculateAmountWithCommission(amount);
            this._paymentGateway.ChargePayment(amountWithCommission);
            this._atm.TakeMoney(amount);
            this._repository.Save(this._atm);

            this.NotifyClient("You have taken " + amount.ToString("C2"));
        }
    }
}