using AutoMapper;
using RateForProfessor.Entities;
using RateForProfessor.Models;
using RateForProfessor.Repositories.Interfaces;
using RateForProfessor.Services.Interfaces;

namespace RateForProfessor.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;
        public CourseService(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        //Course Section
        public Course CreateCourse(Course course)
        {
            try
            {
                var courseEntity = _mapper.Map<CourseEntity>(course);
                var result = _courseRepository.CreateCourse(courseEntity);

                var courseCreated = _mapper.Map<Course>(result);
                return courseCreated;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void DeleteCourse(int id)
        {
            _courseRepository.DeleteCourse(id);
        }

        public List<Course> GetAllCourses()
        {
            var courseEntities = _courseRepository.GetAllCourses();
            var courses = _mapper.Map<List<Course>>(courseEntities);
            return courses;
        }

        public Course GetCourseById(int id)
        {
            var courseEntities = _courseRepository.GetCourseById(id);
            var courses = _mapper.Map<Course>(courseEntities);
            return courses;
        }

        public void UpdateCourse(Course course)
        {
            var existingCourseEntity = _courseRepository.GetCourseById(course.ID);

            if (existingCourseEntity == null)
            {
                throw new Exception("Course not found");
            }
            var updatedCourse = _mapper.Map<CourseEntity>(course);

            _courseRepository.UpdateCourse(updatedCourse);
        }
    }
}
