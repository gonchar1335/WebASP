using System.ComponentModel.DataAnnotations;

namespace WebMVCCource.Models
{
    public class Student
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public int? Age { get; set; }

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
        }
    }
}
