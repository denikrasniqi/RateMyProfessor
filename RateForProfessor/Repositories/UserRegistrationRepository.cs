using RateForProfessor.Context;
using RateForProfessor.Entities;
using RateForProfessor.Models;
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
        public StudentEntity CreateStudent(StudentEntity student)
        {
            _dbContext.Students.Add(student);
            _dbContext.SaveChangesAsync();
            return student;

        }

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
            return _dbContext.Students.Find(email);
            
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
    }
}
