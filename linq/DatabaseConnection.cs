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
            new Student { Name = "Diana", Gender = "Female", UniversityId = 4 }
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
}