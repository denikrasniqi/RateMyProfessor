using RateForProfessor.Context;
using RateForProfessor.Repositories.Interfaces;

namespace RateForProfessor.Repositories
{
    public class RateProfessorRepository : IRateProfessorRepository
    {
        private readonly AppDbContext _dbContext;

        public RateProfessorRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void RateProfessor(int professorId, int studentId, int overallRating, int communicationSkillsRating, int responsivenessRating, int gradingFairnessRating, string feedback)
        {
            throw new NotImplementedException();
        }
    }
}
