using Microsoft.EntityFrameworkCore;
using StudentManagementSystem_VishalMundhra_API.Model;

namespace StudentManagementSystem_VishalMundhra_API
{
    public class ApplicationDbContext : DbContext
    {
        

        public DbSet<Student> Students { get; set; }
        public DbSet<Class> Classes { get; set; }

        public DbSet<StudentClass> StudentClasses { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasIndex(s => s.PhoneNumber).IsUnique();
            modelBuilder.Entity<Student>()
                .HasIndex(s => s.EmailId).IsUnique();

            // Define many-to-many relationship between Student and Class
            modelBuilder.Entity<StudentClass>()
                .HasKey(sc => new { sc.StudentId, sc.ClassId });

            modelBuilder.Entity<StudentClass>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.Classes)
                .HasForeignKey(sc => sc.StudentId);

            modelBuilder.Entity<StudentClass>()
                .HasOne(sc => sc.Class)
                .WithMany(c => c.Students)
                .HasForeignKey(sc => sc.ClassId);
        }
    }

    // Define a join entity for many-to-many relationship
    public class StudentClass
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }
        
        public int ClassId { get; set; }
        public Class Class { get; set; }
    }

}
