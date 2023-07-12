using Microsoft.EntityFrameworkCore;
using RateForProfessor.Context;
using RateForProfessor.Entities;
using RateForProfessor.Models;
using RateForProfessor.Repositories.Interfaces;

namespace RateForProfessor.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext _dbContext;
        public CourseRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public CourseEntity CreateCourse(CourseEntity course)
        {
            _dbContext.Courses.Add(course);
            _dbContext.SaveChanges();
            return course;
        }

        public void DeleteCourse(int id)
        {
            var course = _dbContext.Courses.Find(id);
            _dbContext.Courses.Remove(course);
            _dbContext.SaveChanges();
        }

        public List<CourseEntity> GetAllCourses()
        {
            return _dbContext.Courses.ToList();
        }

        public CourseEntity GetCourseById(int id)
        {
            return _dbContext.Courses.Find(id);
        }

        public void UpdateCourse(CourseEntity course)
        {
            var oldcourse = _dbContext.Courses.Find(course.ID);
            _dbContext.Entry(oldcourse).CurrentValues.SetValues(course);
            _dbContext.SaveChanges();
        }
    }
}
