using System;
using NullReferencesDemo.Presentation.Implementation.CommandResults;
using NullReferencesDemo.Presentation.Interfaces;

namespace NullReferencesDemo.Presentation.Views
{
    public class LoginFailedView : IView
    {
        public LoginFailedView(LoginFailed data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            Data = data;
        }

        private LoginFailed Data { get; }

        public void Render()
        {
            Console.WriteLine("Login failed for user {0}.", Data.Username);
        }
    }
}