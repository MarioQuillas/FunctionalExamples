using System;
using NullReferencesDemo.Presentation.Interfaces;
using NullReferencesDemo.Presentation.PurchaseReports;

namespace NullReferencesDemo.Presentation.Views
{
    public class ProductNotFoundView : IView
    {
        public ProductNotFoundView(ProductNotFound data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            Data = data;
        }

        private ProductNotFound Data { get; }

        public void Render()
        {
            Console.WriteLine(
                "Dear {0},\nSorry to inform you that we have no {1} left.",
                Data.Username,
                Data.ProductName);
        }
    }
}