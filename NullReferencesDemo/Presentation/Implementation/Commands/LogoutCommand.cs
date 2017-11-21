using NullReferencesDemo.Presentation.Implementation.CommandResults;
using NullReferencesDemo.Presentation.Interfaces;

namespace NullReferencesDemo.Presentation.Implementation.Commands
{
    internal class LogoutCommand : ICommand
    {
        private readonly IApplicationServices appServices;

        public LogoutCommand(IApplicationServices appServices)
        {
            this.appServices = appServices;
        }

        public ICommandResult Execute()
        {
            var username = appServices.LoggedInUsername;

            appServices.Logout();

            return new UserLoggedOut(username);
        }
    }
}