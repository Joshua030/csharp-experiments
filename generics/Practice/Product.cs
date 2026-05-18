using Interfaces;

namespace Practice;

public class Product(int id) : IEntity
{
    public int Id { get; private set; } = id;
    public string Name { get; set; }
}
