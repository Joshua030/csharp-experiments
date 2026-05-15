using System;

namespace linq;

public class UniversityManager
{
    public List<University> universities;
    public List<Student> students;

    public UniversityManager()
    {
        universities = [];
        students = [];

        //Let's add some Universities
        universities.Add(new University { Id = 1, Name = "Yale" });
        universities.Add(new University { Id = 2, Name = "Beijing Tech" });

        //Let's add some Students
        students.Add(new Student { Id = 1, Name = "Carla", Gender = "female", Age = 17, UniversityId = 1 });
        students.Add(new Student { Id = 2, Name = "Toni", Gender = "male", Age = 21, UniversityId = 1 });
        students.Add(new Student { Id = 6, Name = "Toni", Gender = "male", Age = 22, UniversityId = 2 });
        students.Add(new Student { Id = 3, Name = "Leyla", Gender = "female", Age = 19, UniversityId = 2 });
        students.Add(new Student { Id = 4, Name = "James", Gender = "trans-gender", Age = 25, UniversityId = 2 });
        students.Add(new Student { Id = 5, Name = "Linda", Gender = "female", Age = 22, UniversityId = 2 });
    }

    public void MaleStudents()
    {
        IEnumerable<Student> maleStudents = students.Where(x => x.Gender == "male");
        Console.WriteLine("Male Students:");

        maleStudents.ToList().ForEach(student => student.Print());
    }

    public void SortStudentsByAge()
    {
        IEnumerable<Student> sortedStudents = students.OrderBy(x => x.Age);
        Console.WriteLine("Students Sorted by Age:");

        sortedStudents.ToList().ForEach(student => student.Print());
    }

    public void AllStudentsFromBeijingTech()
    {
        IEnumerable<Student> bjtStudents = students
          .Join(universities,
              student => student.UniversityId,
              university => university.Id,
              (student, university) => new { student, university })
          .Where(x => x.university.Name == "Beijing Tech")
          .Select(x => x.student);

        Console.WriteLine("Students from Beijing Tech");

        bjtStudents.ToList().ForEach(student => student.Print());
    }

    public void GetStudentsByUniversityId(int universityId)
    {
        IEnumerable<Student> universityStudents = students.
        Where(x => x.UniversityId == universityId);

        if (universityStudents.ToList().Count == 0) Console.WriteLine("We didn't get any match");

        universityStudents.ToList().ForEach(student => student.Print());
    }

    // Possible type of new collection use if we need in more than one place
    //  public record StudentUniversity(string StudentName, string UniversityName);
    public void StudentAndUniversityNameCollection()
    {


        // var newCollection = students.
        // Join(universities,
        // student => student.UniversityId,
        // university => university.Id,
        // (student, university) => new { student, university })
        // .OrderBy(x => x.student.Name).
        // Select(x => new { StudentName = x.student.Name, UniversityName = x.university.Name });

        //Short way
        var newCollection = students
       .Join(
           universities,
           student => student.UniversityId,
           university => university.Id,
           (student, university) => new { StudentName = student.Name, UniversityName = university.Name })
       .OrderBy(x => x.StudentName);

        Console.WriteLine("New Collection: ");
        newCollection.ToList().ForEach(element => Console.WriteLine("Student {0} from University {1}", element.StudentName, element.UniversityName));

    }
}