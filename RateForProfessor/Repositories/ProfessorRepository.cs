using RateForProfessor.Context;
using RateForProfessor.Entities;
using RateForProfessor.Repositories.Interfaces;

namespace RateForProfessor.Repositories
{
    public class ProfessorRepository : IProfessorRepository
    {
        private readonly AppDbContext _dbContext;

        public ProfessorRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ProfessorEntity CreateProfessor(ProfessorEntity professor)
        {
            _dbContext.Profesors.Add(professor);
            _dbContext.SaveChanges();
            return professor;
        }

        public void DeleteProfessor(int id)
        {
            var professor = _dbContext.Profesors.Find(id);
            _dbContext.Profesors.Remove(professor);
            _dbContext.SaveChanges();
        }

        public List<ProfessorEntity> GetAllProfessors()
        {
            return _dbContext.Profesors.ToList();
        }

        public ProfessorEntity GetProfessorById(int id)
        {
            return _dbContext.Profesors.Find(id);
        }

        public void UpdateProfessor(ProfessorEntity professor)
        {
            var oldprofessor = _dbContext.Profesors.Find(professor.ProfessorId);
            _dbContext.Entry(oldprofessor).CurrentValues.SetValues(professor);
            _dbContext.SaveChanges();
        }
    }
}
