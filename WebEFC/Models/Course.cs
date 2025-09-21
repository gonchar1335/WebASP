using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebEFC.Models
{
    // entity class - классы, объекты которых хранятся в бд 
    //[Table("courses")]
    public class Course
    {

        public Course() { }
        public Course(int id, string title, int duration, string description)
        {
            this.Id = id;
            this.Title = title;
            this.Duration = duration;
            this.Description = description;
        }

        // Primary key by defaults - Id, EntityName + Id (CourseId)
        //[Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        
        //[Column("Length")]
        [Range(8,48,ErrorMessage ="Duration out of [8,48]")]
        public int Duration { get; set; }

        //[NotMapped]
        public string? Description { get; set; }

    }
}
