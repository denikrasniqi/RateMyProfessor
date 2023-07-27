using RateForProfessor.Models;

namespace RateForProfessor.Services.Interfaces
{
    public interface IRateProfessorService
    {
        public List<RateProfessor> GetAllRateProfessors();

        //List<RateProfessor> GetOverallRatingProfessors();
        public List<object> GetOverallRatingProfessors();

        public RateProfessor GetRateProfessorById(int id);

        public RateProfessor CreateRateProfessor(RateProfessor rateProfessor);

        public void UpdateRateProfessor(RateProfessor rateProfessor);

        public void DeleteRateProfessor(int id);

        List<RateProfessor> GetRateProfessorsByProfessorId(int professorId);

        List<RateProfessor> GetRateProfessorsByStudentId(int studentId);

        public int CalculateOverall(int communicationskills, int responsiveness,
            int gradingfairness);
    }
}
