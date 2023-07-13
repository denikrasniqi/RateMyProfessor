using RateForProfessor.Context;
using RateForProfessor.Entities;
using RateForProfessor.Models;
using RateForProfessor.Repositories.Interfaces;

namespace RateForProfessor.Repositories
{
    public class RateUniversityRepository : IRateUniversityRepository
    {
        private readonly AppDbContext _dbContext;

        public RateUniversityRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public RateUniversityEntity CreateRateUniversity(RateUniversityEntity rateUniversity)
        {
            _dbContext.RateUniversities.Add(rateUniversity);
            _dbContext.SaveChanges();
            return rateUniversity;
        }

        public void DeleteRateUniversity(int id)
        {
            var rateUniversity = _dbContext.RateUniversities.Find(id);

            if(rateUniversity != null) 
            {
                _dbContext.RateUniversities.Remove(rateUniversity);
                _dbContext.SaveChanges();
            }

        }
        public List<RateUniversityEntity> GetAllRateUniversity()
        {
            return _dbContext.RateUniversities.ToList();
        }

        public RateUniversityEntity GetRateUniversityById(int id)
        {
            return _dbContext.RateUniversities.Find(id);
        }
        public List<RateUniversityEntity> GetRateUniversitysByUniversityId(int universityId)
        {
            return _dbContext.RateUniversities
                .Where(ru => ru.UniversityId == universityId)
                .ToList();
        }

        public List<RateUniversityEntity> GetRateUniversityByStudentId(int studentId)
        {
            return _dbContext.RateUniversities
                .Where(ru => ru.StudentId == studentId)
                .ToList();
        }

        public void UpdateRateUniversity(RateUniversityEntity rateUniversity)
        {
            var updateRateUniversity = _dbContext.RateUniversities.Find(rateUniversity.Id);

            if(updateRateUniversity != null)
            {
                updateRateUniversity.Overall = rateUniversity.Overall;
                updateRateUniversity.Feedback = rateUniversity.Feedback;

                _dbContext.SaveChanges();
            }
        }
    }
}
