using Academy.Core.Entities;
using Academy.Infrastructure.Interface;
using System.Collections.Generic;

namespace Academy.Application.Services
{
    public class StudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public void AddStudent(Student student)
        {
            _studentRepository.AddStudent(student);
        }

        public void UpdateStudent(Student student)
        {
            _studentRepository.UpdateStudent(student);
        }

        public void DeleteStudent(int id)
        {
            _studentRepository.DeleteStudent(id);
        }

        public Student GetStudentById(int id)
        {
            return _studentRepository.GetStudentById(id);
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _studentRepository.GetAllStudents();
        }
    }
}
