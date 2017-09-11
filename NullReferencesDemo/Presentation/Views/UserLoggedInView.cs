namespace NullReferencesDemo.Presentation.Views
{
    using System;

    using NullReferencesDemo.Presentation.Implementation.CommandResults;
    using NullReferencesDemo.Presentation.Interfaces;

    public class UserLoggedInView : IView
    {
        public UserLoggedInView(UserLoggedIn data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            this.Data = data;
        }

        private UserLoggedIn Data { get; }

        public void Render()
        {
            Console.WriteLine("User {0} logged in; {1:C2} available", this.Data.Username, this.Data.Balance);
        }
    }
}