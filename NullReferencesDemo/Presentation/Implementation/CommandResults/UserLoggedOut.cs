namespace NullReferencesDemo.Presentation.Implementation.CommandResults
{
    using NullReferencesDemo.Presentation.Interfaces;

    public class UserLoggedOut : ICommandResult
    {
        public UserLoggedOut(string username)
        {
            this.Username = username ?? string.Empty;
        }

        public string Username { get; }
    }
}