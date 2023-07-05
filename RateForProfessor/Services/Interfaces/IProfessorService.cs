using RateForProfessor.Models;

namespace RateForProfessor.Services.Interfaces
{
    public interface IProfessorService
    {
        public List<Professor> GetAllProfessors();

        public Professor GetProfessorById(int id);

        public Professor CreateProfessor(Professor professor);

        public void UpdateProfessor(Professor professor);

        public void DeleteProfessor(int id);
    }
}
