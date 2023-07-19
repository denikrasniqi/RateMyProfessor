using RateForProfessor.Models;

namespace RateForProfessor.Services.Interfaces
{
    public interface IUserRegistrationService
    {
        public List<Student> GetAllStudents();

        public Student GetStudentById(int id);

        public Student GetStudentByEmail(string email);
        public Student GetStudentByName(string name);

        public Student CreateStudent(Student student, string photoPath);

        public void UpdateStudent(Student student);

        public void DeleteStudent(int id);

        public void UploadProfilePhoto(int studentId, string photoPath);
    }
}
