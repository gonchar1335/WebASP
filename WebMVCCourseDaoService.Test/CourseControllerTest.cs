using Microsoft.AspNetCore.Mvc;
using WebMVCCourseDaoService.Controllers;
using WebMVCCourseDaoService.Dao;
using WebMVCCourseDaoService.Models;

namespace WebMVCCourseDaoService.Test
{

    class FakeCourseData : ICourseDao
    {
        private IEnumerable<Course> courses = new List<Course>()
        {
            new Course(1, "C# Lang 13", 40),
            new Course(2, "ASP.NET Core MVC 9.0", 40),
            new Course(3, "JavaScript 1. Base", 24),
            new Course(4, "Pattern OOP", 24),
            new Course(5, "JavaScript 2. Base", 35),
        };
        public IEnumerable<Course> All { get => courses; set => throw new NotImplementedException(); }

        public Course Add(Course course)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Course> Get()
        {
            return courses;
        }

        public Course Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Course Update(Course course)
        {
            throw new NotImplementedException();
        }
    }
    public class CourseControllerTest
    {
        [Fact]
        public void SearchTest()
        {
            //Arrange
            var c = new CourseController(new FakeCourseData());

            //Act
            ViewResult? vr = c.Search("jAvA") as ViewResult;

            //Assert
            Assert.Equal(2, ((IEnumerable<Course>)vr!.ViewData.Model!).Count());

        }
    }
}
