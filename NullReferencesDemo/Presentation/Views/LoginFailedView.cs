namespace NullReferencesDemo.Presentation.Views
{
    using System;

    using NullReferencesDemo.Presentation.Implementation.CommandResults;
    using NullReferencesDemo.Presentation.Interfaces;

    public class LoginFailedView : IView
    {
        public LoginFailedView(LoginFailed data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            this.Data = data;
        }

        private LoginFailed Data { get; }

        public void Render()
        {
            Console.WriteLine("Login failed for user {0}.", this.Data.Username);
        }
    }
}