using RateForProfessor.Extensions;
using RateForProfessor.Models;

namespace RateForProfessor.Services.Interfaces
{
    public interface IUniversityService
    {
        public List<University> GetAllUniversites();

        public University GetUniversityById(int id);
        public University GetUniversityByName(string name);

        public University CreateUniversitiy(University university);

        public void UpdateUniversity (University university);

        public void DeleteUniversity(int id);

        public List<University> SearchUniversities(Search search);
    }
}
