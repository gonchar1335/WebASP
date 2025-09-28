using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.Xml;
using WebMVCCource.Models;

namespace WebMVCCourse.Test
{
    public class CourseTest
    {
        [Fact]
        public void DurationValidTest()
        {
            // Arrange
            Course course = new Course(1,"Java 1", 40);

            //Act
            course.Duration = 32;

            var errorCount = course.Validate(new ValidationContext(course)).Count();
            //var r = errorCount.Where(vr => vr.ErrorMessage!.Contains("duration") && vr.ErrorMessage.Contains("invalid")).Count();

            //Assert
            //Assert.Equal(1, r);
            Assert.Equal(0, errorCount);
        }
    }
}
