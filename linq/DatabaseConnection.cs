using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Models;

public static class DatabaseConnection
{
    private static AppDbContext? appDbContext = null;
    private static AppDbContext GetInstance()
    {

        if (appDbContext == null)
        {
            var config = new ConfigurationBuilder()
         .AddJsonFile("appsettings.json")
         .Build();

            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer(config.GetConnectionString("DefaultConnection"))
                .Options;

            appDbContext = new AppDbContext(options);
        }


        return appDbContext;
    }


    public static List<Student> GetStudents()
    {
        var db = GetInstance();
        db.Database.EnsureCreated();

        var students = db.Students
            .Include(s => s.University)
            .ToList();

        Console.WriteLine("Students from Database:");
        foreach (var s in students)
        {
            Console.WriteLine("Id: {0}, Name: {1}, Gender: {2}, University: {3}",
                s.Id, s.Name, s.Gender, s.University?.Name ?? "(none)");
        }

        return students;
    }

    public static List<University> GetUniversities()
    {
        var db = GetInstance();
        db.Database.EnsureCreated();

        var universities = db.Universities
            .ToList();

        Console.WriteLine("Universities from Database:");
        foreach (var u in universities)
        {
            Console.WriteLine("Id: {0}, Name: {1}", u.Id, u.Name);
        }

        return universities;
    }

    public static void GetLectures()
    {
        var db = GetInstance();
        db.Database.EnsureCreated();

        IQueryable<Lecture> lectures = db.Lectures;

        Console.WriteLine("Lecture from database");

        lectures.ToList().ForEach(lecture => Console.WriteLine("Id: {0}, Name: {1}", lecture.Id, lecture.Name));
    }

    public static void GetStudentsWithLectureAndUniversity()
    {
        var db = GetInstance();
        db.Database.EnsureCreated();

        IQueryable<Student> students = db.Students
          .Include(s => s.University)
          .Include(s => s.StudentLectures)
              .ThenInclude(sl => sl.Lecture)
          ;

        Console.WriteLine("Students from Database with Lectures and University:");
        students.ToList().ForEach(student =>
        {
            Console.WriteLine("Id: {0}, Name: {1}, Gender: {2}, University: {3}",
                student.Id, student.Name, student.Gender, student.University?.Name ?? "(none)");
            student.StudentLectures.ToList().ForEach(sl =>
            {
                Console.WriteLine("  Lecture Id: {0}, Name: {1}", sl.LectureId, sl.Lecture?.Name ?? "(none)");
            });
        });
    }

    public static void GetAllStudentsFromYale()
    {
        var db = GetInstance();
        db.Database.EnsureCreated();

        IQueryable<Student> students = db.Students
        .Where(s => s.University.Name == "Yale University")
        .Include(s => s.StudentLectures)
            .ThenInclude(sl => sl.Lecture)
        ;

        Console.WriteLine("Students from Database with Lectures and University:");
        students.ToList().ForEach(student =>
        {
            Console.WriteLine("Id: {0}, Name: {1}, Gender: {2}, University: {3}",
                student.Id, student.Name, student.Gender, student.University?.Name ?? "(none)");
            student.StudentLectures.ToList().ForEach(sl =>
            {
                Console.WriteLine("  Lecture Id: {0}, Name: {1}", sl.LectureId, sl.Lecture?.Name ?? "(none)");
            });
        });

    }

    public static void GetAllUniversitiesWithFemaleGender()
    {
        var db = GetInstance();
        db.Database.EnsureCreated();

        var universities = db.Universities
      .Where(u => u.Students.Any(s => s.Gender == "Female"))
      .Select(u => u.Name);

        Console.WriteLine("Female Students from Database with University:");
        universities.ToList().ForEach(u =>
        {
            Console.WriteLine("University: {0}", u);
        });
    }

    public static void InsertUniversities()
    {
        var db = GetInstance();

        var names = new[] { "Yale University", "Universidad de Deusto", "UPV/EHU", "MIT" };

        var existing = db.Universities
            .Where(u => names.Contains(u.Name))
            .Select(u => u.Name)
            .ToHashSet();

        var toInsert = names
            .Where(n => !existing.Contains(n))
            .Select(n => new University { Name = n })
            .ToList();

        if (toInsert.Count == 0)
        {
            Console.WriteLine("All universities already exist.");
            return;
        }

        db.Universities.AddRange(toInsert);
        db.SaveChanges();
        Console.WriteLine($"Inserted {toInsert.Count} new universities");
    }

    public static void InsertStudents()
    {
        var db = GetInstance();

        var students = new[]
        {
            new Student { Name = "Alice", Gender = "Female", UniversityId = 1 },
            new Student { Name = "Bob", Gender = "Male", UniversityId = 2 },
            new Student { Name = "Charlie", Gender = "Male", UniversityId = 3 },
            new Student { Name = "Diana", Gender = "Female", UniversityId = 4 },

        };

        var existing = db.Students
            .Where(s => students.Select(st => st.Name).Contains(s.Name))
            .Select(s => s.Name)
            .ToHashSet();

        var toInsert = students
            .Where(s => !existing.Contains(s.Name))
            .ToList();

        if (toInsert.Count == 0)
        {
            Console.WriteLine("All students already exist.");
            return;
        }

        db.Students.AddRange(toInsert);
        db.SaveChanges();
        Console.WriteLine($"Inserted {toInsert.Count} new students");
    }

    public static void InsertLectures()
    {
        var db = GetInstance();

        var lectures = new[]
        {
              new Lecture { Name = "Mathematics" },
              new Lecture { Name = "Physics" },
              new Lecture { Name = "Chemistry" },
              new Lecture { Name = "Biology" }
          };

        var existing = db.Lectures
            .Where(l => lectures.Select(le => le.Name).Contains(l.Name))
            .Select(l => l.Name)
            .ToHashSet();

        var toInsert = lectures
            .Where(l => !existing.Contains(l.Name))
            .ToList();

        if (toInsert.Count == 0)
        {
            Console.WriteLine("All lectures already exist.");
            return;
        }

        db.Lectures.AddRange(toInsert);
        db.SaveChanges();
        Console.WriteLine($"Inserted {toInsert.Count} new lectures");
    }

    public static void InsertStudentLectureAssociations()
    {
        var db = GetInstance();

        var studentsLecture = new[]
        {
        new StudentLecture{ StudentId = 1, LectureId = 1 },
        new StudentLecture{ StudentId = 1, LectureId = 2 },
        new StudentLecture{ StudentId = 1, LectureId = 3 },
        new StudentLecture{ StudentId = 2, LectureId = 3 },
        new StudentLecture{ StudentId = 3, LectureId = 1 },
    };

        var studentIds = studentsLecture.Select(s => s.StudentId).Distinct().ToList();
        var lectureIds = studentsLecture.Select(s => s.LectureId).Distinct().ToList();

        // Pre-filter on the server with simple Contains, then match pairs in memory
        var existing = db.StudentLectures
            .Where(sl => studentIds.Contains(sl.StudentId) && lectureIds.Contains(sl.LectureId))
            .Select(sl => new { sl.StudentId, sl.LectureId })
            .AsEnumerable()
            .ToHashSet();

        var toInsert = studentsLecture
            .Where(sl => !existing.Contains(new { sl.StudentId, sl.LectureId }))
            .ToList();

        if (toInsert.Count == 0)
        {
            Console.WriteLine("All student-lecture associations already exist.");
            return;
        }

        db.StudentLectures.AddRange(toInsert);
        db.SaveChanges();
        Console.WriteLine($"Inserted {toInsert.Count} new student-lecture associations");
    }

    public static void UpdateBob()
    {
        var db = GetInstance();
        db.Database.EnsureCreated();


        var bob = db.Students.FirstOrDefault(s => s.Name == "Bob");
        if (bob != null)
        {
            bob.Gender = "Unknown";
            db.SaveChanges();
            Console.WriteLine("Updated Bob's gender.");
        }
        else
        {
            Console.WriteLine("Bob not found.");
        }
    }


    public static void DeleteBob()
    {
        var db = GetInstance();
        db.Database.EnsureCreated();

        var bob = db.Students.FirstOrDefault(s => s.Name == "Bob");
        if (bob != null)
        {
            db.Students.Remove(bob);
            db.SaveChanges();
            Console.WriteLine("Deleted Bob.");
        }
        else
        {
            Console.WriteLine("Bob not found.");
        }
    }
}