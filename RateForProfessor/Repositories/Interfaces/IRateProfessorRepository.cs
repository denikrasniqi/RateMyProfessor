using RateForProfessor.Entities;

namespace RateForProfessor.Repositories.Interfaces
{
    public interface IRateProfessorRepository
    {
        public List<RateProfessorEntity> GetAllRateProfessors();

        public RateProfessorEntity GetRateProfessorById(int id);

        public RateProfessorEntity CreateRateProfessor(RateProfessorEntity rateProfessor);

        public void UpdateRateProfessor(RateProfessorEntity rateProfessor);

        public void DeleteRateProfessor(int id);

        public List<RateProfessorEntity> GetRateProfessorsByProfessorId(int professorId);

        public List<RateProfessorEntity> GetRateProfessorsByStudentId(int studentId);
    }
}
