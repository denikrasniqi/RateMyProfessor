using RateForProfessor.Entities;
using System.Text.RegularExpressions;

namespace RateForProfessor.Repositories.Interfaces
{
    public interface IUserRegistrationRepository
    {
        public List<StudentEntity> GetAllStudents();

        public StudentEntity GetStudentById(int id);

        public StudentEntity GetStudentByEmail(string email);

        public StudentEntity CreateStudent(StudentEntity student);

        public void UpdateStudent(StudentEntity student);

        public void DeleteStudent(int id);
    }
}
