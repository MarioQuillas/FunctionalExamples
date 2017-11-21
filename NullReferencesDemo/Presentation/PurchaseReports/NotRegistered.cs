using NullReferencesDemo.Presentation.Interfaces;

namespace NullReferencesDemo.Presentation.PurchaseReports
{
    public class NotRegistered : IPurchaseReport
    {
        public NotRegistered(string username)
        {
            Username = username;
        }

        public string Username { get; }
    }
}