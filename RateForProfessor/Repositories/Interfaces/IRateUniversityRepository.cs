using RateForProfessor.Entities;

namespace RateForProfessor.Repositories.Interfaces
{
    public interface IRateUniversityRepository
    {
        public List<RateUniversityEntity> GetAllRateUniversity();
        public RateUniversityEntity GetRateUniversityById(int id);

        public RateUniversityEntity CreateRateUniversity(RateUniversityEntity rateUniversity);

        public void UpdateRateUniversity(RateUniversityEntity rateUniversity);

        public void DeleteRateUniversity(int id);

        public List<RateUniversityEntity> GetRateUniversitysByUniversityId(int universityId);

        public List<RateUniversityEntity> GetRateUniversityByStudentId(int studentId);
    }
}
