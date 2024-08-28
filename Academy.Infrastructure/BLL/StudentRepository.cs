using Academy.Core.Entities;
using Academy.Infrastructure.DAL;
using Academy.Infrastructure.Interface;
using System.Collections.Generic;
using System.Data.SQLite;

namespace Academy.Infrastructure.BLL
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Student> GetAllStudents()
        {
            var students = new List<Student>();

            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                string query = "SELECT Id, FirstName, LastName, DateOfBirth, Email FROM Students";

                using (var command = new SQLiteCommand(query, (SQLiteConnection)connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            students.Add(new Student
                            {
                                Id = reader.GetInt32(0),
                                FirstName = reader.GetString(1),
                                LastName = reader.GetString(2),
                                DateOfBirth = reader.GetDateTime(3),
                                Email = reader.GetString(4)
                            });
                        }
                    }
                }
            }

            return students;
        }

        public void AddStudent(Student student)
        {
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                string query = "INSERT INTO Students (FirstName, LastName, DateOfBirth, Email) VALUES (@FirstName, @LastName, @DateOfBirth, @Email)";

                using (var command = new SQLiteCommand(query, (SQLiteConnection)connection))
                {
                    command.Parameters.AddWithValue("@FirstName", student.FirstName);
                    command.Parameters.AddWithValue("@LastName", student.LastName);
                    command.Parameters.AddWithValue("@DateOfBirth", student.DateOfBirth.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@Email", student.Email);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateStudent(Student student)
        {
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                string updateQuery = @"
            UPDATE Students
            SET FirstName = @FirstName,
                LastName = @LastName,
                DateOfBirth = @DateOfBirth,
                Email = @Email
            WHERE Id = @Id";

                using (var command = new SQLiteCommand(updateQuery, (SQLiteConnection)connection))
                {
                    command.Parameters.AddWithValue("@Id", student.Id);
                    command.Parameters.AddWithValue("@FirstName", student.FirstName);
                    command.Parameters.AddWithValue("@LastName", student.LastName);
                    command.Parameters.AddWithValue("@DateOfBirth", student.DateOfBirth.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@Email", student.Email);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteStudent(int id)
        {
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                string deleteQuery = "DELETE FROM Students WHERE Id = @Id";

                using (var command = new SQLiteCommand(deleteQuery, (SQLiteConnection)connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public Student GetStudentById(int id)
        {
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                string selectQuery = "SELECT Id, FirstName, LastName, DateOfBirth, Email FROM Students WHERE Id = @Id";
                Student student = null;

                using (var command = new SQLiteCommand(selectQuery, (SQLiteConnection)connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            student = new Student
                            {
                                Id = reader.GetInt32(0),
                                FirstName = reader.GetString(1),
                                LastName = reader.GetString(2),
                                DateOfBirth = reader.GetDateTime(3),
                                Email = reader.GetString(4)
                            };
                        }
                    }
                }

                return student;
            }
        }
    }
}