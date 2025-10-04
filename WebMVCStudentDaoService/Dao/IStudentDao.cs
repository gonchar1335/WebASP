using WebMVCStudentDaoService.Models;

namespace WebMVCStudentDaoService.Dao
{
    public interface IStudentDao
    {
        public IEnumerable<Student> Allow { get; set; }
        public IEnumerable<Student> Get();
        public Student Get(int? id);
        public IEnumerable<Student> GetByTitle(string title);
        public Student Add(Student course);
        public Student Update(Student course);
        public void Remove(int id);
    }
}
