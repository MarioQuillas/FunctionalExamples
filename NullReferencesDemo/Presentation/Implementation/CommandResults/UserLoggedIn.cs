using NullReferencesDemo.Presentation.Interfaces;

namespace NullReferencesDemo.Presentation.Implementation.CommandResults
{
    public class UserLoggedIn : ICommandResult
    {
        public UserLoggedIn(string username, decimal balance)
        {
            Username = username ?? string.Empty;
            Balance = balance;
        }

        public decimal Balance { get; }

        public string Username { get; }
    }
}