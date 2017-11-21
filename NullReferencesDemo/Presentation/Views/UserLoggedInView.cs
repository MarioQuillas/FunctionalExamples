using System;
using NullReferencesDemo.Presentation.Implementation.CommandResults;
using NullReferencesDemo.Presentation.Interfaces;

namespace NullReferencesDemo.Presentation.Views
{
    public class UserLoggedInView : IView
    {
        public UserLoggedInView(UserLoggedIn data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            Data = data;
        }

        private UserLoggedIn Data { get; }

        public void Render()
        {
            Console.WriteLine("User {0} logged in; {1:C2} available", Data.Username, Data.Balance);
        }
    }
}