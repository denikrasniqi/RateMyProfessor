using RateForProfessor.Models;

namespace RateForProfessor.Services.Interfaces
{
    public interface ICourseService
    {
        public List<Course> GetAllCourses();

        public Course GetCourseById(int id);
        //Krijimi i logjikes
        public Course CreateCourse(Course course);

        public void UpdateCourse(Course course);

        public void DeleteCourse(int id);
    }
}
