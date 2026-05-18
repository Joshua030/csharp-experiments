using Interfaces;

namespace Practice;

public class User : IEntity
{
    public int Id { get; private set; }
    public string Name { get; set; }
}
