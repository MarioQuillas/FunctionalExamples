namespace NullReferencesDemo.Presentation.Views
{
    using System;

    using NullReferencesDemo.Presentation.Interfaces;
    using NullReferencesDemo.Presentation.PurchaseReports;

    public class ReceiptView : IView
    {
        public ReceiptView(Receipt data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            this.Data = data;
        }

        private Receipt Data { get; }

        public void Render()
        {
            Console.WriteLine(
                "Dear {0},\nThank you for buying {1} for {2:C}.",
                this.Data.Username,
                this.Data.ProductName,
                this.Data.Price);
        }
    }
}