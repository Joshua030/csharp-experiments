// Data/AppDbContext.cs
namespace Data;

using Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<University> Universities => Set<University>();
    public DbSet<Student> Students => Set<Student>();
    public DbSet<Lecture> Lectures => Set<Lecture>();
    public DbSet<StudentLecture> StudentLectures => Set<StudentLecture>();

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder b)
    {
        b.Entity<Student>(e =>
        {
            e.ToTable("Student");
            e.Property(s => s.Name).HasColumnType("varchar(50)");
            e.Property(s => s.Gender).HasColumnType("varchar(50)");
        });

        b.Entity<Lecture>(e =>
        {
            e.ToTable("Lecture");
            e.Property(l => l.Name).HasColumnType("varchar(50)");
        });

        b.Entity<University>(e =>
        {
            e.ToTable("University");
            e.Property(u => u.Name).HasColumnType("varchar(50)");
        });

        b.Entity<StudentLecture>(e =>
        {
            e.ToTable("StudentLecture");
            e.HasOne(sl => sl.Student)
             .WithMany(s => s.StudentLectures)
             .HasForeignKey(sl => sl.StudentId)
             .OnDelete(DeleteBehavior.Cascade);

            e.HasOne(sl => sl.Lecture)
             .WithMany(l => l.StudentLectures)
             .HasForeignKey(sl => sl.LectureId)
             .OnDelete(DeleteBehavior.Cascade);
        });
    }
}