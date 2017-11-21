using System;
using NullReferencesDemo.Presentation.Interfaces;
using NullReferencesDemo.Presentation.PurchaseReports;

namespace NullReferencesDemo.Presentation.Views
{
    public class ReceiptView : IView
    {
        public ReceiptView(Receipt data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            Data = data;
        }

        private Receipt Data { get; }

        public void Render()
        {
            Console.WriteLine(
                "Dear {0},\nThank you for buying {1} for {2:C}.",
                Data.Username,
                Data.ProductName,
                Data.Price);
        }
    }
}