namespace NullReferencesDemo.Presentation.Implementation.CommandResults
{
    using NullReferencesDemo.Presentation.Interfaces;

    public class UserLoggedIn : ICommandResult
    {
        public UserLoggedIn(string username, decimal balance)
        {
            this.Username = username ?? string.Empty;
            this.Balance = balance;
        }

        public decimal Balance { get; }

        public string Username { get; }
    }
}