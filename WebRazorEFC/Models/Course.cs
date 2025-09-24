using System.ComponentModel.DataAnnotations;

namespace WebRazorEFC.Models
{
    public class Course
    {
        public int Id { get; set; }
        [StringLength(maximumLength: 64, MinimumLength = 4, ErrorMessage = "Title length should be >= 4")]
        public string? Title { get; set; }
        [Range(8, 48, ErrorMessage = "Course duration should in [8,48]")]

        public int Duration { get; set; }
        public string? Description { get; set; }

        public Course() { }
        public Course(int id, string title, int duration, string description)
        {
            this.Id = id;
            this.Title = title;
            this.Duration = duration;
            this.Description = description;
        }
    }
}
