using Microsoft.EntityFrameworkCore;
using WebRazorEFC.Models;

namespace WebRazorEFC
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Course> Courses { get; set; } = null!;
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
        //Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().HasData(
                new Course(1, "C# Lang 13", 40, "C# Intro"),
                new Course(2, "ASP.NET Core MVC 9.0", 40, "Creating web app with ASP.NET Core"),
                new Course(3, "JavaScript 1. Base", 24, "JavaScript Intro"),
                new Course(4, "Pattern OOP", 24, "Pattern OOP"),
                new Course(5, "C# Client-Server", 40, "Client-server C#"),
                new Course(6, "GIT", 16, "Git Intro")
            );

            // this.Database.GetDbConnection(); работа напрямую с бд
        }
    }
    
}
