using System.ComponentModel.DataAnnotations;

namespace Labs4.Models
{
    
    public class Student
    {

        public int? Id { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }

        public static IList<Student> All = new List<Student>()
        {
            new Student(1,"Anton",30),
            new Student(2,"Sveta", 34),
            new Student(3,"Jonn", 40),
            new Student(4,"Kirill", 50)
        };

        public Student() 
        {

        }
        public Student(int id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age; 
        }
    }
}
