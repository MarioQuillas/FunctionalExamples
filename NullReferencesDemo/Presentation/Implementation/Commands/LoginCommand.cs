using System;
using NullReferencesDemo.Presentation.Implementation.CommandResults;
using NullReferencesDemo.Presentation.Interfaces;

namespace NullReferencesDemo.Presentation.Implementation.Commands
{
    internal class LoginCommand : ICommand
    {
        private readonly IApplicationServices appServices;

        public LoginCommand(IApplicationServices appServices)
        {
            this.appServices = appServices;
        }

        public ICommandResult Execute()
        {
            Console.Write("Enter username: ");
            var username = Console.ReadLine();

            if (appServices.Login(username))
                return new UserLoggedIn(username, appServices.LoggedInUserBalance);

            return new LoginFailed(username);
        }
    }
}