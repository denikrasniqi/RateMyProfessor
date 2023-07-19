using RateForProfessor.Entities;

namespace RateForProfessor.Repositories.Interfaces
{
    public interface ICourseRepository
    {
        public List<CourseEntity> GetAllCourses();

        public CourseEntity GetCourseById(int id);

        public CourseEntity CreateCourse(CourseEntity course);

        public void UpdateCourse(CourseEntity course);

        public void DeleteCourse(int id);
    }
}
