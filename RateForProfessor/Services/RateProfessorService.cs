using AutoMapper;
using RateForProfessor.Entities;
using RateForProfessor.Models;
using RateForProfessor.Repositories;
using RateForProfessor.Repositories.Interfaces;
using RateForProfessor.Services.Interfaces;

namespace RateForProfessor.Services
{
    public class RateProfessorService : IRateProfessorService
    {
        private readonly IRateProfessorRepository _rateProfessorRepository;
        private readonly IMapper _mapper;
        private readonly IProfessorRepository _professorRepository;

        public RateProfessorService(IRateProfessorRepository rateProfessorRepository, IMapper mapper, IProfessorRepository professorRepository)
        {
            _rateProfessorRepository = rateProfessorRepository;
            _mapper = mapper;
            _professorRepository = professorRepository;
        }

        public RateProfessor CreateRateProfessor(RateProfessor rateProfessor)
        {
            try
            {               
                var rateEntity = _mapper.Map<RateProfessorEntity>(rateProfessor);
                var profesorId = rateEntity.ProfessorId;                
                var result = _rateProfessorRepository.CreateRateProfessor(rateEntity);

                var rateCreated = _mapper.Map<RateProfessor>(result);
                return rateCreated;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void DeleteRateProfessor(int id)
        {
            _rateProfessorRepository.DeleteRateProfessor(id);
        }

        public List<RateProfessor> GetAllRateProfessors()
        {
            var rateProfessorEntities = _rateProfessorRepository.GetAllRateProfessors();
            var rateRrofessors = _mapper.Map<List<RateProfessor>>(rateProfessorEntities);
            return rateRrofessors;
        }

        public RateProfessor GetRateProfessorById(int id)
        {
            var rateEntity = _rateProfessorRepository.GetRateProfessorById(id);
            var rateProfessor = _mapper.Map<RateProfessor>(rateEntity);
            return rateProfessor;
        }

        public List<RateProfessor> GetRateProfessorsByProfessorId(int professorId)
        {
            var rateProfessors = _rateProfessorRepository.GetRateProfessorsByProfessorId(professorId);
            return _mapper.Map<List<RateProfessor>>(rateProfessors);

        }

        public List<RateProfessor> GetRateProfessorsByStudentId(int studentId)
        {
            var rateProfessors = _rateProfessorRepository.GetRateProfessorsByStudentId(studentId);
            return _mapper.Map<List<RateProfessor>>(rateProfessors);
        }

        public void UpdateRateProfessor(RateProfessor rateProfessor)
        {
            var existingRateProfessorEntity = _rateProfessorRepository.GetRateProfessorById(rateProfessor.Id);

            if (existingRateProfessorEntity == null)
            {
                throw new Exception("Rate professor not found");
            }
            var updatedRateProfessor = _mapper.Map<RateProfessorEntity>(rateProfessor);

            _rateProfessorRepository.UpdateRateProfessor(updatedRateProfessor);
        }   
        public int CalculateOverall(int communicationskills, int responsiveness,
            int gradingfairness)
        {
            int overall = (communicationskills + responsiveness + gradingfairness) / 3;
            return overall;
        }

        public List<ProfessorOverallRating> GetOverallRatingProfessors()
        {
            var professorRatings = _rateProfessorRepository.GetAllRateProfessors()
                .Join(
                    _professorRepository.GetAllProfessors(),
                    rateProfessor => rateProfessor.ProfessorId,
                    professor => professor.ProfessorId,
                    (rateProfessor, professor) => new ProfessorOverallRating
                    {
                        ProfessorId = rateProfessor.ProfessorId,
                        FirstName = professor.FirstName,
                        LastName = professor.LastName,
                        OverallRating = (int)rateProfessor.Overall,
                        CommunicationSkills = (int)rateProfessor.CommunicationSkills,
                        Responsiveness = (int)rateProfessor.Responsiveness,
                        GradingFairness = (int)rateProfessor.GradingFairness
                    }
                )
                .GroupBy(r => r.ProfessorId)
                .Select(g => new ProfessorOverallRating
                {
                    ProfessorId = g.Key,
                    FirstName = g.First().FirstName,
                    LastName = g.First().LastName,
                    OverallRating = (int)g.Average(r => r.OverallRating),
                    CommunicationSkills = (int)g.Average(r => r.CommunicationSkills),
                    Responsiveness = (int)g.Average(r => r.Responsiveness),
                    GradingFairness = (int)g.Average(r => r.GradingFairness)
                })
                .ToList();

            return professorRatings;
        }
    }
}
