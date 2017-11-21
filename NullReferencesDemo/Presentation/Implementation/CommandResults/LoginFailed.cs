using NullReferencesDemo.Presentation.Interfaces;

namespace NullReferencesDemo.Presentation.Implementation.CommandResults
{
    public class LoginFailed : ICommandResult
    {
        public LoginFailed(string username)
        {
            Username = username ?? string.Empty;
        }

        public string Username { get; }
    }
}