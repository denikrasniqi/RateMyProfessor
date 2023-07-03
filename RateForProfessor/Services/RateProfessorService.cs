using AutoMapper;
using RateForProfessor.Repositories.Interfaces;
using RateForProfessor.Services.Interfaces;

namespace RateForProfessor.Services
{
    public class RateProfessorService : IRateProfessorService
    {
        private readonly IRateProfessorRepository _rateProfessorRepository;
        private readonly IMapper _mapper;

        public RateProfessorService(IRateProfessorRepository rateProfessorRepository, IMapper mapper)
        {
            _rateProfessorRepository = rateProfessorRepository;
            _mapper = mapper;
        }
        public void RateProfessor(int professorId, int studentId, int overallRating, int communicationSkillsRating, int responsivenessRating, int gradingFairnessRating, string feedback)
        {
            throw new NotImplementedException();
        }
    }
}
