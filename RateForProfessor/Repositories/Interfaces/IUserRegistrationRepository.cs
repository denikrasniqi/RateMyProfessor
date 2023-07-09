using RateForProfessor.Entities;

namespace RateForProfessor.Repositories.Interfaces
{
    public interface IUserRegistrationRepository
    {
        public List<StudentEntity> GetAllStudents();

        public StudentEntity GetStudentById(int id);

        public StudentEntity GetStudentByEmail(string email);

        //public StudentEntity CreateStudent(StudentEntity student);
        StudentEntity CreateStudent(StudentEntity student, string photoPath);

        public void UpdateStudent(StudentEntity student);

        public void DeleteStudent(int id);

        public void UploadProfilePhoto(int studentId, string photoPath);
    }
}
