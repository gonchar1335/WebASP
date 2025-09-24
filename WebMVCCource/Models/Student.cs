using System.ComponentModel.DataAnnotations;
using WebMVCCource.Attributes;

namespace WebMVCCource.Models
{
    
    public class Student
    {
        [Required]
        public int? Id { get; set; }
        [RegularExpression("^[A-Z][a-z]*$", ErrorMessage = "Name must First char Upper, next char Lower")]
        [StringLength(maximumLength: 200, MinimumLength = 3, ErrorMessage = "Title length should be >= 3")]
        public string? Name { get; set; }
        [Range(18, 120, ErrorMessage = "Student duration should in [18, 120]")]
        public int? Age { get; set; }
        
        [AddressVerification(ErrorMessage = "The address must consist of three parts separated by commas")]
        public string? Address { get; set; } //(.+),(.+),(.+)

        public static IList<Student> All = new List<Student>()
        {
            new Student(1,"Anton",30,"Russia"),
            new Student(2,"Sveta", 34,"USA"),
            new Student(3,"Jonn", 40,"Germany"),
            new Student(4,"Kirill", 50,"Russia")
        };

        public Student() 
        {

        }
        public Student(int id, string name, int age,string address)
        {
            Id = id;
            Name = name;
            Age = age;
            Address = address;  
        }
    }
}
