using NullReferencesDemo.Presentation.Interfaces;

namespace NullReferencesDemo.Presentation.Implementation.CommandResults
{
    public class UserRegistered : ICommandResult
    {
        public UserRegistered(string username)
        {
            Username = username ?? string.Empty;
        }

        public string Username { get; }
    }
}