namespace NullReferencesDemo.Presentation.Views
{
    using System;

    using NullReferencesDemo.Presentation.Interfaces;
    using NullReferencesDemo.Presentation.PurchaseReports;

    public class NotEnoughMoneyView : IView
    {
        public NotEnoughMoneyView(NotEnoughMoney data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            this.Data = data;
        }

        private NotEnoughMoney Data { get; }

        public void Render()
        {
            Console.WriteLine(
                "Dear {0},\nYou do not have {1:C} to pay for the {2}.",
                this.Data.Username,
                this.Data.Price,
                this.Data.ProductName);
        }
    }
}