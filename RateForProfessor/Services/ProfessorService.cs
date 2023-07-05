using AutoMapper;
using RateForProfessor.Entities;
using RateForProfessor.Models;
using RateForProfessor.Repositories.Interfaces;
using RateForProfessor.Services.Interfaces;

namespace RateForProfessor.Services
{
    public class ProfessorService : IProfessorService
    {
        private readonly IProfessorRepository _professorRepository;
        private readonly IMapper _mapper;

        public ProfessorService(IProfessorRepository professorRepository, IMapper mapper)
        {
            _professorRepository = professorRepository;
            _mapper = mapper;
        }
        public Professor CreateProfessor(Professor professor)
        {
            try
            {
                var professorEntity = _mapper.Map<ProfessorEntity>(professor);
                var result = _professorRepository.CreateProfessor(professorEntity);

                var professorCreated = _mapper.Map<Professor>(result);
                return professorCreated;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void DeleteProfessor(int id)
        {
            _professorRepository.DeleteProfessor(id);
        }

        public List<Professor> GetAllProfessors()
        {
            var professorEntities = _professorRepository.GetAllProfessors();
            var professors = _mapper.Map<List<Professor>>(professorEntities);
            return professors;
        }

        public Professor GetProfessorById(int id)
        {
            var professorEntity = _professorRepository.GetProfessorById(id);
            var professor = _mapper.Map<Professor>(professorEntity);
            return professor;
        }

        public void UpdateProfessor(Professor professor)
        {
            var existingProfessorEntity = _professorRepository.GetProfessorById(professor.ProfessorId);

            if (existingProfessorEntity == null)
            {
                throw new Exception("Professor not found");
            }
            var updatedProfessor = _mapper.Map<ProfessorEntity>(professor);

            _professorRepository.UpdateProfessor(updatedProfessor);
        }
    }
}
