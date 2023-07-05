using AutoMapper;
using RateForProfessor.Entities;
using RateForProfessor.Models;
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

        public RateProfessor CreateRateProfessor(RateProfessor rateProfessor)
        {
            try
            {
                var rateEntity = _mapper.Map<RateProfessorEntity>(rateProfessor);
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
    }
}
