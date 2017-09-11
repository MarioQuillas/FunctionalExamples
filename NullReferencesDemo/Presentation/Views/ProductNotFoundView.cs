namespace NullReferencesDemo.Presentation.Views
{
    using System;

    using NullReferencesDemo.Presentation.Interfaces;
    using NullReferencesDemo.Presentation.PurchaseReports;

    public class ProductNotFoundView : IView
    {
        public ProductNotFoundView(ProductNotFound data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            this.Data = data;
        }

        private ProductNotFound Data { get; }

        public void Render()
        {
            Console.WriteLine(
                "Dear {0},\nSorry to inform you that we have no {1} left.",
                this.Data.Username,
                this.Data.ProductName);
        }
    }
}