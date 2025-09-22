using Microsoft.EntityFrameworkCore;
using WebEFCStudent.Models;

namespace WebEFCStudent
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Student> Students { get; set; } = null!;

        public ApplicationDbContext() { }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
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
