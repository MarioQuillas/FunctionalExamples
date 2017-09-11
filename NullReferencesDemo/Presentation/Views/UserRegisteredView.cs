namespace NullReferencesDemo.Presentation.Views
{
    using System;

    using NullReferencesDemo.Presentation.Implementation.CommandResults;
    using NullReferencesDemo.Presentation.Interfaces;

    public class UserRegisteredView : IView
    {
        public UserRegisteredView(UserRegistered data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            this.Data = data;
        }

        private UserRegistered Data { get; }

        public void Render()
        {
            Console.WriteLine("User {0} is now registered.", this.Data.Username);
        }
    }
}