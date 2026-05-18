using Interfaces;

namespace Repositories;

public class Repository<T> : IRepository<T> where T : IEntity
{
    public void Add(T entity)
    {
        throw new NotImplementedException();
    }

    public void Remove(T entity)
    {
        throw new NotImplementedException();
    }
}
