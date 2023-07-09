using RateForProfessor.Context;
using RateForProfessor.Entities;
using RateForProfessor.Repositories.Interfaces;

namespace RateForProfessor.Repositories
{
    public class UserRegistrationRepository : IUserRegistrationRepository
    {
        private readonly AppDbContext _dbContext;

        public UserRegistrationRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /*public StudentEntity CreateStudent(StudentEntity student)
        {
            _dbContext.Students.Add(student);
            _dbContext.SaveChanges();
            return student;
        }*/



        /*public StudentEntity CreateStudent(StudentEntity student, string photoPath)
        {
            _dbContext.Students.Add(student);
            _dbContext.SaveChanges();

            // Ngarkoni fotografinë e profilit
            string fileName = Path.GetFileName(photoPath);
            string profilePhotoPath = Path.Combine("profile_photos", fileName);
            File.Copy(photoPath, profilePhotoPath);

            // Përditëso objektin StudentEntity me rrugën e fotografi
            student.ProfilePhoto = profilePhotoPath;

            _dbContext.SaveChanges();

            return student;
        }*/


        public void DeleteStudent(int id)
        {
            var student = _dbContext.Students.Find(id);
            _dbContext.Students.Remove(student);
            _dbContext.SaveChanges();
        }

        public List<StudentEntity> GetAllStudents()
        {
            return _dbContext.Students.ToList();
        }

        public StudentEntity GetStudentByEmail(string email)
        {
            var student = _dbContext.Students.FirstOrDefault(s => s.Email == email);
            return student;
        }

        public StudentEntity GetStudentById(int id)
        {
            return _dbContext.Students.Find(id);
        }

        public void UpdateStudent(StudentEntity student)
        {
            var oldstudent = _dbContext.Students.Find(student.StudentId);
            _dbContext.Entry(oldstudent).CurrentValues.SetValues(student);
            _dbContext.SaveChanges();
        
        }

        public StudentEntity CreateStudent(StudentEntity student, string photoPath)
        {
            _dbContext.Students.Add(student);
            _dbContext.SaveChanges();

            student.ProfilePhotoPath = photoPath;
            _dbContext.SaveChanges();

            return student;
        }

        public void UploadProfilePhoto(int studentId, string photoPath)
        {
            var student = _dbContext.Students.Find(studentId);
            if (student != null)
            {
                student.ProfilePhotoPath = photoPath;
                _dbContext.SaveChanges();
            }
        }
    }
}
