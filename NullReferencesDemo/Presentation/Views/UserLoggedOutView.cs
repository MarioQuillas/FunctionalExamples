namespace NullReferencesDemo.Presentation.Views
{
    using System;

    using NullReferencesDemo.Presentation.Implementation.CommandResults;
    using NullReferencesDemo.Presentation.Interfaces;

    public class UserLoggedOutView : IView
    {
        public UserLoggedOutView(UserLoggedOut data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            this.Data = data;
        }

        private UserLoggedOut Data { get; }

        public void Render()
        {
            Console.WriteLine("User {0} logged out.", this.Data.Username);
        }
    }
}