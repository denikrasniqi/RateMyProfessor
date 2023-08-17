using RateForProfessor.Models;
using System.Security.Cryptography;

namespace RateForProfessor.Services.Interfaces
{
    public interface IRateUniversityService
    {
        public List<RateUniversity> GetAllRateUniversity();

        public RateUniversity GetRateUniversityById(int id);

        public RateUniversity CreateRateUniversity(RateUniversity rateUniversity);

        public void UpdateRateUniversity(RateUniversity rateUniversity);

        public  void DeleteRateUniversity(int id);

        List<RateUniversity> GetRateUniversityByUniversiyId(int universityId);

        List<RateUniversity> GetRateUniversityByStudentId( int studentId);

        public List<UniversityOverallRating> GetOverallRatingUniversities();
    }
}
