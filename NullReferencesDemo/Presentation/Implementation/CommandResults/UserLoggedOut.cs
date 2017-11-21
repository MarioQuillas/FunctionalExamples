using NullReferencesDemo.Presentation.Interfaces;

namespace NullReferencesDemo.Presentation.Implementation.CommandResults
{
    public class UserLoggedOut : ICommandResult
    {
        public UserLoggedOut(string username)
        {
            Username = username ?? string.Empty;
        }

        public string Username { get; }
    }
}