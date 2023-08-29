using Microsoft.EntityFrameworkCore;
using RateForProfessor.Context;
using RateForProfessor.Entities;
using RateForProfessor.Extensions;
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

        public void DeleteStudent(int id)
        {
            var student = _dbContext.Students.Find(id);
            _dbContext.Students.Remove(student);
            _dbContext.SaveChanges();
        }

        public List<StudentEntity> GetAllStudents()
        {
            return _dbContext.Students.Include(s => s.User).ToList();
        }

        public StudentEntity GetStudentByEmail(string email)
        {
            //var student = _dbContext.Students.Join(_dbContext.Users,
            //                student => student.UserId,
            //                user => user.UserId,
            //                (student, user) => new { Student = student, User = user })
            //            .FirstOrDefault(joined => joined.User.Email == email)?
            //            .Student;
            //return student;

            return _dbContext.Students.Include(s => s.User).FirstOrDefault(s => s.User.Email == email);
        }

        public StudentEntity GetStudentById(int id)
        {
            //return _dbContext.Students.Find(id);
            return _dbContext.Students.Include(s => s.User).FirstOrDefault(s => s.StudentId == id);
        }

        public StudentEntity GetStudentByName(string name)
        {
            //var student = _dbContext.Students.FirstOrDefault(s => s.Name == name);
            //return student;

            return _dbContext.Students.Include(s => s.User).FirstOrDefault(s => s.User.Name == name);

        }

        /*        public void UpdateStudent(StudentEntity student)
                {
                    var oldstudent = _dbContext.Students.Find(student.StudentId);
                    _dbContext.Entry(oldstudent).CurrentValues.SetValues(student);
                    _dbContext.SaveChanges();
                }*/
        public void UpdateStudent(StudentEntity student, string photoPath)
        {
            var oldstudent = _dbContext.Students.Find(student.StudentId);
            oldstudent.ProfilePhotoPath = photoPath;
            _dbContext.Entry(oldstudent).CurrentValues.SetValues(student);
            _dbContext.SaveChanges();
        }

        public StudentEntity CreateStudent(StudentEntity student, string photoPath)
        {
            student.ProfilePhotoPath = photoPath;
            _dbContext.Students.Add(student);
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
