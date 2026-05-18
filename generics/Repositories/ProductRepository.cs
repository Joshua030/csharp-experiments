namespace Repositories;

using Interfaces;
using Practice;

public class ProductRepository : IRepository<Product>
{
    private readonly List<Product> _products = new();

    public void Add(Product entity)
    {
        _products.Add(entity);
    }

    public void Remove(Product entity)
    {
        _products.Remove(entity);
    }
}
