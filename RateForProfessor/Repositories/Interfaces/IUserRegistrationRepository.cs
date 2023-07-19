using RateForProfessor.Entities;

namespace RateForProfessor.Repositories.Interfaces
{
    public interface IUserRegistrationRepository
    {
        public List<StudentEntity> GetAllStudents();

        public StudentEntity GetStudentById(int id);

        public StudentEntity GetStudentByEmail(string email);

        StudentEntity CreateStudent(StudentEntity student, string photoPath);

        public void UpdateStudent(StudentEntity student);

        public void DeleteStudent(int id);

        public StudentEntity GetStudentByName(string name);
        
        public void UploadProfilePhoto(int studentId, string photoPath);

    }
}
