using AutoMapper;
using RateForProfessor.Entities;
using RateForProfessor.Models;

namespace RateForProfessor.Mappings
{
    public class UniversityProfileMapping:Profile
    {
        public UniversityProfileMapping()
        {
            CreateMap<University, UniversityEntity>().ReverseMap();
        }
    }
}
