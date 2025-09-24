using Microsoft.EntityFrameworkCore;
using WebRazorEFCStudent.Models;

namespace WebRazorEFCStudent
{
    public class ApplicationContext:DbContext
    {
        public DbSet<Student> Students { get; set; } = null!;
        public ApplicationContext() { }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated(); // создание базы
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            string connectionString = Program.config.GetConnectionString("DefaultConnection")!;
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                    new Student(1, "Anton", 30, "Russia"),
                    new Student(2, "Sveta", 34, "USA"),
                    new Student(3, "Jonn", 40, "Germany"),
                    new Student(4, "Kirill", 50, "Russia")
                );
        }

    }
}
