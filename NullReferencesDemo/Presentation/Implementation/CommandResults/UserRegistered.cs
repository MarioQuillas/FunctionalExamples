namespace NullReferencesDemo.Presentation.Implementation.CommandResults
{
    using NullReferencesDemo.Presentation.Interfaces;

    public class UserRegistered : ICommandResult
    {
        public UserRegistered(string username)
        {
            this.Username = username ?? string.Empty;
        }

        public string Username { get; }
    }
}