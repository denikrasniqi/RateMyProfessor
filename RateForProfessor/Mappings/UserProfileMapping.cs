using AutoMapper;
using RateForProfessor.Entities;
using RateForProfessor.Models;

namespace RateForProfessor.Mappings
{
    public class UserProfileMapping : Profile
    {
        public UserProfileMapping()
        {
            CreateMap<Student, StudentEntity>().ReverseMap();

            CreateMap<User, UserEntity>().ReverseMap();
            
            CreateMap<Student, UserEntity>().ReverseMap();

            CreateMap<Professor, ProfessorEntity>().ReverseMap();

            CreateMap<RateProfessor, RateProfessorEntity>().ReverseMap();

            CreateMap<Department, DepartmentEntity>().ReverseMap();

            CreateMap<Course, CourseEntity>().ReverseMap();

            CreateMap<News, NewsEntity>().ReverseMap();

            //CreateMap<University, UniversityEntity>().ReverseMap();
        }
    }
}
