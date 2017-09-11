namespace NullReferencesDemo.Presentation.Views
{
    using System;

    using NullReferencesDemo.Presentation.Interfaces;

    public class FailedPurchaseView : IView
    {
        public void Render()
        {
            Console.WriteLine("Purchase failed.");
        }
    }
}