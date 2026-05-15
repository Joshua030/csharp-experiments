namespace Models;

public class Lecture
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public ICollection<StudentLecture> StudentLectures { get; set; } = new List<StudentLecture>();
}