using Microsoft.AspNetCore.Mvc;
using RateForProfessor.Entities;
using RateForProfessor.Extensions;

namespace RateForProfessor.Repositories.Interfaces
{
    public interface IProfessorRepository
    {
        public List<ProfessorEntity> GetAllProfessors();

        public ProfessorEntity GetProfessorById(int id);

        public ProfessorEntity CreateProfessor(ProfessorEntity professor);

        public void UpdateProfessor(ProfessorEntity professor);

        public void DeleteProfessor(int id);


        public List<ProfessorEntity> SearchProfessors(Search search);

    }
}
