using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMVCStudentDaoService.Controllers;
using WebMVCStudentDaoService.Dao;
using WebMVCStudentDaoService.Models;

namespace WebMVCStudentDaoService.Test
{
    public class StudentControllerMoqTest
    {
        public IEnumerable<Student>? Students 
        {
            get 
            {
                yield return new Student(1, "Anton", 30, "Russia");
                yield return new Student(2, "Sveta", 34, "USA");
                yield return new Student(3, "Jonn", 40, "Germany");
                yield return new Student(4, "Antonina", 32, "Russia");
                yield return new Student(5, "Kirill", 50, "Russia");
                yield return new Student(6, "Ant", 33, "Russia");
            }
        }

        [Fact]
        public void SearchTestMoq() 
        {
            var moq = new Mock<IStudentDao>();

            moq.SetupGet(m => m.Allow).Returns(Students!);

            var stCont = new StudentController(moq.Object);

            // act

            ViewResult? vr = stCont.Search("ant") as ViewResult;


            //assert
            Assert.Equal(3, ((IEnumerable<Student>)vr!.ViewData.Model!).Count());
        }
    }
}
