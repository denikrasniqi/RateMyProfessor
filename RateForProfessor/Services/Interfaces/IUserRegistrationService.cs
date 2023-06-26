using RateForProfessor.Models;

namespace RateForProfessor.Services.Interfaces
{
    public interface IUserRegistrationService
    {
        public List<Student> GetAllStudents();

        public Student GetStudentById(int id);

        public Student GetStudentByEmail(string email);

        public Student CreateStudent(Student student);

        public void UpdateStudent(Student student);

        public void DeleteStudent(int id);
    }
}
