using WebMVCStudentDaoService.Models;

namespace WebMVCStudentDaoService.Dao
{
    public class StudentDaoInMemory:IStudentDao
    {
        public static IList<Student> All = new List<Student>()
        {
            new Student(1,"Anton",30,"Russia"),
            new Student(2,"Sveta", 34,"USA"),
            new Student(3,"Jonn", 40,"Germany"),
            new Student(4,"Kirill", 50,"Russia")
        };

        IEnumerable<Student> IStudentDao.Allow { get => Get(); set => throw new NotImplementedException(); }

        public Student Add(Student student)
        {
            student.Id = All.Select(x => x.Id).Max() + 1;
            All.Add(student);
            return student;
        }

        public IEnumerable<Student> Get()
        {
            return All;
        }

        public Student Get(int? id)
        {
            return  All.Where(st => st.Id == id).SingleOrDefault()!;
        }

        public IEnumerable<Student> GetByTitle(string name)
        {
            return All.Where(st=> st.Name == name);
        }

        public void Remove(int id)
        {
            All.Remove(Get(id));
        }

        public Student Update(Student student)
        {
            var st = Get(student.Id);
            if (st != null)
            {
                st.Name = student.Name;
                st.Address = student.Address;
                st.Age = student.Age;
            }
            else 
            {
                throw new Exception($"Update Student by ID {student.Id} not found");
            }
            return st;
        }
    }
}
