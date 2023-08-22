using RateForProfessor.Entities;
using RateForProfessor.Extensions;

namespace RateForProfessor.Repositories.Interfaces
{
    public interface IUniversityRepository
    {
        public List<UniversityEntity> GetAllUniversites();

        public UniversityEntity GetUniversityById(int id);

        public UniversityEntity GetUniversityByName(string name);

        public UniversityEntity CreateUniversity(UniversityEntity university, string photoPath);

        public void UpdateUniversity (UniversityEntity university, string photoPath);

        public void DeleteUniversity(int id);

        public void UploadProfilePhoto(int universityId, string photoPath);
      
        public List<UniversityEntity> SearchUniversities(Search search);
    }
}
