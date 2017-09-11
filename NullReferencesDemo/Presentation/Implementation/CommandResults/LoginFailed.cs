namespace NullReferencesDemo.Presentation.Implementation.CommandResults
{
    using NullReferencesDemo.Presentation.Interfaces;

    public class LoginFailed : ICommandResult
    {
        public LoginFailed(string username)
        {
            this.Username = username ?? string.Empty;
        }

        public string Username { get; }
    }
}