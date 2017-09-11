namespace NullReferencesDemo.Presentation.Views
{
    using System;

    using NullReferencesDemo.Presentation.Interfaces;
    using NullReferencesDemo.Presentation.PurchaseReports;

    public class NotRegisteredView : IView
    {
        public NotRegisteredView(NotRegistered data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            this.Data = data;
        }

        private NotRegistered Data { get; }

        public void Render()
        {
            Console.Write("User {0} is not registered.", this.Data.Username);
        }
    }
}