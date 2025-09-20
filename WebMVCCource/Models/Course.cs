using System.ComponentModel.DataAnnotations;

namespace WebMVCCource.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Title should not be empty")]
        [StringLength(maximumLength: 64, MinimumLength = 4, ErrorMessage = "Title length should be >= 4")]
        public string? Title { get; set; }
        [Range(8,48, ErrorMessage = "Course duration should in [8,48]")]

        public int Duration { get; set; }
        public static IList<Course> All { get; set; }
        static Course()
        {
            All = new List<Course>() { 
                new Course(1,"C# Lang 13", 40),
                new Course(2,"ASP.NET Core MVC 9.0", 40),
                new Course(3,"JavaScript 1. Base", 24),
                new Course(4,"Pattern OOP", 24),
                new Course(5,"C# Client-Server", 40),
                new Course(6,"GIT", 16),
            };
        }

        public Course() { }

        public Course(int id, string title, int duration)
        {
            Id = id;
            Title = title;
            Duration = duration;
        }
    }

    
}
