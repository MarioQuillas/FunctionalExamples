namespace NullReferencesDemo.Presentation.PurchaseReports
{
    using NullReferencesDemo.Presentation.Interfaces;

    public class NotRegistered : IPurchaseReport
    {
        public NotRegistered(string username)
        {
            this.Username = username;
        }

        public string Username { get; }
    }
}