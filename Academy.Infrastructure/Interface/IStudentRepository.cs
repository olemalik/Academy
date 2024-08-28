using Academy.Core.Entities;
using System.Collections.Generic;

namespace Academy.Infrastructure.Interface
{
    public interface IStudentRepository
    {
        void AddStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(int id);
        Student GetStudentById(int id);
        IEnumerable<Student> GetAllStudents();
    }
}
