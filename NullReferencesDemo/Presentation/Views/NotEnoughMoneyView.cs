using System;
using NullReferencesDemo.Presentation.Interfaces;
using NullReferencesDemo.Presentation.PurchaseReports;

namespace NullReferencesDemo.Presentation.Views
{
    public class NotEnoughMoneyView : IView
    {
        public NotEnoughMoneyView(NotEnoughMoney data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            Data = data;
        }

        private NotEnoughMoney Data { get; }

        public void Render()
        {
            Console.WriteLine(
                "Dear {0},\nYou do not have {1:C} to pay for the {2}.",
                Data.Username,
                Data.Price,
                Data.ProductName);
        }
    }
}