using RateForProfessor.Context;
using RateForProfessor.Entities;
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

        public RateProfessorEntity CreateRateProfessor(RateProfessorEntity rateProfessor)
        {
            _dbContext.RateProfessors.Add(rateProfessor);
            _dbContext.SaveChanges();
            return rateProfessor;
        }

        public void DeleteRateProfessor(int id)
        {
            var rateProfessor = _dbContext.RateProfessors.Find(id);

            if (rateProfessor != null)
            {
                _dbContext.RateProfessors.Remove(rateProfessor);
                _dbContext.SaveChanges();
            }
        }

        public RateProfessorEntity GetRateProfessorById(int id)
        {
            return _dbContext.RateProfessors.Find(id);
        }

        public List<RateProfessorEntity> GetAllRateProfessors()
        {
            return _dbContext.RateProfessors.ToList();
        }

        public List<RateProfessorEntity> GetRateProfessorsByProfessorId(int professorId)
        {
            return _dbContext.RateProfessors
                .Where(rp => rp.ProfessorId == professorId)
                .ToList();
        }

        public List<RateProfessorEntity> GetRateProfessorsByStudentId(int studentId)
        {
            return _dbContext.RateProfessors
                .Where(rp => rp.StudentId == studentId)
                .ToList();
        }

        public void UpdateRateProfessor(RateProfessorEntity rateProfessor)
        {
            var updateRateProfessor = _dbContext.RateProfessors.Find(rateProfessor.Id);

            if (updateRateProfessor != null)
            {
                updateRateProfessor.Overall = rateProfessor.Overall;
                updateRateProfessor.CommunicationSkills = rateProfessor.CommunicationSkills;
                updateRateProfessor.Responsiveness = rateProfessor.Responsiveness;
                updateRateProfessor.GradingFairness = rateProfessor.GradingFairness;
                updateRateProfessor.Feedback = rateProfessor.Feedback;

                _dbContext.SaveChanges();
            }
        }
    }
}
