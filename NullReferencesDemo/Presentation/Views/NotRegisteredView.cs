using System;
using NullReferencesDemo.Presentation.Interfaces;
using NullReferencesDemo.Presentation.PurchaseReports;

namespace NullReferencesDemo.Presentation.Views
{
    public class NotRegisteredView : IView
    {
        public NotRegisteredView(NotRegistered data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            Data = data;
        }

        private NotRegistered Data { get; }

        public void Render()
        {
            Console.Write("User {0} is not registered.", Data.Username);
        }
    }
}