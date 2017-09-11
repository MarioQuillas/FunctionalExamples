namespace NullReferencesDemo.Presentation.Implementation.Commands
{
    using NullReferencesDemo.Presentation.Implementation.CommandResults;
    using NullReferencesDemo.Presentation.Interfaces;

    internal class LogoutCommand : ICommand
    {
        private IApplicationServices appServices;

        public LogoutCommand(IApplicationServices appServices)
        {
            this.appServices = appServices;
        }

        public ICommandResult Execute()
        {
            string username = this.appServices.LoggedInUsername;

            this.appServices.Logout();

            return new UserLoggedOut(username);
        }
    }
}