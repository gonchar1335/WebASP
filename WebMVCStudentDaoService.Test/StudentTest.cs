using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebMVCStudentDaoService.Controllers;
using WebMVCStudentDaoService.Dao;
using WebMVCStudentDaoService.Models;

namespace WebMVCStudentDaoService.Test
{

    class FakeStudentData : IStudentDao
    {
        private IEnumerable<Student> students = new List<Student>()
        {
            new Student(1,"Anton",30,"Russia"),
            new Student(2,"Sveta", 34,"USA"),
            new Student(3,"Jonn", 40,"Germany"),
            new Student(4,"Antonina", 32,"Russia"),
            new Student(5,"Kirill", 50,"Russia"),
            new Student(6,"Ant", 33,"Russia"),
        };

        public IEnumerable<Student> All { get => students; set => throw new NotImplementedException(); }

        public Student Add(Student course)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> Get()
        {
            return students;
        }

        public Student Get(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Student Update(Student course)
        {
            throw new NotImplementedException();
        }
    }
    public class StudentTest
    {
        [Fact]
        public void AgeValidTest()
        {
            Student student = new Student(1,"Anton",30, "Russia");

            var errorCount = student.Validate(new ValidationContext(student)).Count();

            Assert.Equal(0,errorCount);
        }

        [Fact]
        public void SearchTest()
        {
            var stController = new StudentController(new FakeStudentData());
            ViewResult? vr = stController.Search("ant") as ViewResult;

            Assert.Equal(3, ((IEnumerable<Student>)vr!.ViewData.Model!).Count());
        }
    }
}
