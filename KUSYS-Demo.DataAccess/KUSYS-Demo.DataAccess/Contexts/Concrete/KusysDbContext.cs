using KUSYS_Demo.DataAccess.Contexts.Abstract;
using KUSYS_Demo.DataAccess.Entitites;
using Microsoft.EntityFrameworkCore;

namespace KUSYS_Demo.DataAccess.Contexts.Concrete
{
    public class KusysDbContext : DbContext, IKusysDbContext
    {
        public KusysDbContext() { }
        public KusysDbContext(DbContextOptions<KusysDbContext> options) : base(options)
        {
        }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public async Task Save()
        {
            await SaveChangesAsync();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Adding seed data for first migration.
            modelBuilder.Entity<Course>().HasData(
                new Course()
                {
                    CourseId = "CSI101",
                    CourseName = "Introduction to Computer Science",
                },
                 new Course()
                 {
                     CourseId = "CSI102",
                     CourseName = "Algorithms",
                 },
                  new Course()
                  {
                      CourseId = "MAT101",
                      CourseName = "Calculus",
                  },
                 new Course()
                 {
                     CourseId = "PHY101",
                     CourseName = "Physics",
                 });
        }
    }
}
