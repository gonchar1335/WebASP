using System.ComponentModel.DataAnnotations;

namespace WebRazorEFCStudent.Models
{
    public class Student
    {
        [Required]
        public int Id { get; set; }
        [RegularExpression("^[A-Z][a-z]*$", ErrorMessage = "Name must First char Upper, next char Lower")]
        [StringLength(maximumLength: 200, MinimumLength = 3, ErrorMessage = "Title length should be >= 3")]
        public string? Name { get; set; }
        [Range(18, 120, ErrorMessage = "Student duration should in [18, 120]")]
        public int? Age { get; set; }

        public string? Address { get; set; }

        public Student()
        {

        }
        public Student(int id, string name, int age, string address)
        {
            Id = id;
            Name = name;
            Age = age;
            Address = address;
        }
    }
}
