using System.Collections.Generic;
using NullReferencesDemo.Domain.Interfaces;

namespace NullReferencesDemo.Infrastructure.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly IDictionary<string, IUser> usernameToUser = new Dictionary<string, IUser>();

        public void Add(IUser user)
        {
            usernameToUser.Add(user.Username, user);
        }

        public IEnumerable<IUser> Find(string username)
        {
            IUser user = null;

            if (!usernameToUser.TryGetValue(username, out user)) return new IUser[0];

            return new[] {user};
        }
    }
}