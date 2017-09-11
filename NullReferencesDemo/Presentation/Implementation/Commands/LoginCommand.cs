namespace NullReferencesDemo.Presentation.Implementation.Commands
{
    using System;

    using NullReferencesDemo.Presentation.Implementation.CommandResults;
    using NullReferencesDemo.Presentation.Interfaces;

    internal class LoginCommand : ICommand
    {
        private IApplicationServices appServices;

        public LoginCommand(IApplicationServices appServices)
        {
            this.appServices = appServices;
        }

        public ICommandResult Execute()
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();

            if (this.appServices.Login(username))
                return new UserLoggedIn(username, this.appServices.LoggedInUserBalance);

            return new LoginFailed(username);
        }
    }
}