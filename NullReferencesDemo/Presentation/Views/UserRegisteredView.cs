using System;
using NullReferencesDemo.Presentation.Implementation.CommandResults;
using NullReferencesDemo.Presentation.Interfaces;

namespace NullReferencesDemo.Presentation.Views
{
    public class UserRegisteredView : IView
    {
        public UserRegisteredView(UserRegistered data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            Data = data;
        }

        private UserRegistered Data { get; }

        public void Render()
        {
            Console.WriteLine("User {0} is now registered.", Data.Username);
        }
    }
}