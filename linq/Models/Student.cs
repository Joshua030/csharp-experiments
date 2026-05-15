namespace Models;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Gender { get; set; } = null!;
    public int UniversityId { get; set; }
    public University University { get; set; } = null!;
    public ICollection<StudentLecture> StudentLectures { get; set; } = new List<StudentLecture>();
}