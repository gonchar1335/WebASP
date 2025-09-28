using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMVCCourseDaoService.Controllers;
using WebMVCCourseDaoService.Dao;
using WebMVCCourseDaoService.Models;

namespace WebMVCCourseDaoService.Test
{
    public class CourseControllerMoqTest
    {
        public IEnumerable<Course>? Courses 
        {
            get 
            {
                yield return new Course(1, "C# Lang 13", 40);
                yield return new Course(2, "ASP.NET Core MVC 9.0", 40);
                yield return new Course(3, "JavaScript 1. Base", 24);
                yield return new Course(4, "Pattern OOP", 24);
            }
        }
        [Fact]
        public void SearchTest2()
        {
            //Arrange
            var moq = new Mock<ICourseDao>();
            moq.Setup(m => m.All).Returns(Courses!);

            var c = new CourseController(moq.Object);

            //Act
            ViewResult? vr = c.Search("Lang") as ViewResult;

            //Assert


            //Assert.IsType<IEnumerable<Course>>((IEnumerable<Course>)vr!.ViewData.Model!);
            Assert.Equal(1, ((IEnumerable<Course>)vr!.ViewData.Model!).Count());


  
        }
    }
}
