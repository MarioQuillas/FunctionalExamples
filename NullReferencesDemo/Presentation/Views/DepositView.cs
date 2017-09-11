namespace NullReferencesDemo.Presentation.Views
{
    using System;

    using NullReferencesDemo.Presentation.Implementation.CommandResults;
    using NullReferencesDemo.Presentation.Interfaces;

    public class DepositView : IView
    {
        public DepositView(DepositResult data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            this.Data = data;
        }

        private DepositResult Data { get; }

        public void Render()
        {
            Console.WriteLine(
                "User {0} has deposited {1:C2}; {2:C2} available.",
                this.Data.Username,
                this.Data.Amount,
                this.Data.Balance);
        }
    }
}