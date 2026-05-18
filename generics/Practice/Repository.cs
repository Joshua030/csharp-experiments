namespace Practice;

using Interfaces;

// Constraints with interfaces
public class Repository<T> where T : IEntity
{
    private List<T> values = [];


    public void Add(T entity)
    {
        values.Add(entity);
    }

}
