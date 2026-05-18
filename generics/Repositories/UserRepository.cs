using Interfaces;

namespace Repositories;

using Interfaces;
using Practice;

public class UserRepository : IRepository<User>
{
    private readonly List<User> _users = new();

    public void Add(User entity)
    {
        _users.Add(entity);
    }

    public void Remove(User entity)
    {
        _users.Remove(entity);
    }
}
