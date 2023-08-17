using Microsoft.AspNetCore.Mvc;
using RateForProfessor.Context;
using RateForProfessor.Entities;
using RateForProfessor.Extensions;
using RateForProfessor.Models;
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

        public ProfessorEntity CreateProfessor(ProfessorEntity professor, string photoPath)
        {
            professor.ProfilePhotoPath = photoPath;
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

        public ProfessorEntity GetProfessorByName(string name)
        {
            var professor = _dbContext.Profesors.FirstOrDefault(p => p.FirstName == name);
            return professor;
        }

        public void UpdateProfessor(ProfessorEntity professor)
        {
            var oldprofessor = _dbContext.Profesors.Find(professor.ProfessorId);
            //oldprofessor.ProfilePhotoPath = photoPath;
            _dbContext.Entry(oldprofessor).CurrentValues.SetValues(professor);
            //oldprofessor.ProfilePhotoPath = photoPath;
            _dbContext.SaveChanges();
        }

        public List<ProfessorEntity> SearchProfessors(Search search)
        {
            var query = _dbContext.Profesors.Search(search.SearchTerm).AsQueryable();
            var professors = query.ToList();
            return professors;
        }

        public void UploadProfilePhoto(int professorId, string photoPath)
        {
            var student = _dbContext.Students.Find(professorId);
            if (student != null)
            {
                student.ProfilePhotoPath = photoPath;
                _dbContext.SaveChanges();
            }
        }
    }
}
