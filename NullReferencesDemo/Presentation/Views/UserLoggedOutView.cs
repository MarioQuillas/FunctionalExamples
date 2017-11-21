using System;
using NullReferencesDemo.Presentation.Implementation.CommandResults;
using NullReferencesDemo.Presentation.Interfaces;

namespace NullReferencesDemo.Presentation.Views
{
    public class UserLoggedOutView : IView
    {
        public UserLoggedOutView(UserLoggedOut data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            Data = data;
        }

        private UserLoggedOut Data { get; }

        public void Render()
        {
            Console.WriteLine("User {0} logged out.", Data.Username);
        }
    }
}