using RateForProfessor.Models;

namespace RateForProfessor.Services.Interfaces
{
    public interface IRateProfessorService
    {
        public List<RateProfessor> GetAllRateProfessors();

        public RateProfessor GetRateProfessorById(int id);

        public RateProfessor CreateRateProfessor(RateProfessor rateProfessor);

        public void UpdateRateProfessor(RateProfessor rateProfessor);

        public void DeleteRateProfessor(int id);

        List<RateProfessor> GetRateProfessorsByProfessorId(int professorId);

        List<RateProfessor> GetRateProfessorsByStudentId(int studentId);
    }
}
