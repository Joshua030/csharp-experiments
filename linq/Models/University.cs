namespace Models;

public class University
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public ICollection<Student> Students { get; set; } = new List<Student>();
}