using System.ComponentModel.DataAnnotations;

namespace WebMVCCourseDaoService.Models
{
    public class Course: IValidatableObject
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Title should not be empty")]
        [StringLength(maximumLength: 64, MinimumLength = 4, ErrorMessage = "Title length should be >= 4")]
        public string? Title { get; set; }
        [Range(8,48, ErrorMessage = "Course duration should in [8,48]")]

        public int Duration { get; set; }

        public Course() { }

        public Course(int id, string title, int duration)
        {
            Id = id;
            Title = title;
            Duration = duration;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Id < 0)
                yield return new ValidationResult("id < 0");
            if (Duration % 8 != 0)
                yield return new ValidationResult("duration % 8 != 0 invalid");
        }
    }

    
}
