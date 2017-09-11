namespace NullReferencesDemo.Domain.Interfaces
{
    using System.Collections.Generic;

    public interface IUserRepository
    {
        void Add(IUser user);

        IEnumerable<IUser> Find(string username);
    }
}