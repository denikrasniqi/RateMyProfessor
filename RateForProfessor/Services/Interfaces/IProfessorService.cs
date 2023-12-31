﻿using RateForProfessor.Extensions;
using RateForProfessor.Models;

namespace RateForProfessor.Services.Interfaces
{
    public interface IProfessorService
    {
        public List<Professor> GetAllProfessors();

        public Professor GetProfessorById(int id);

        public Professor CreateProfessor(Professor professor, string photoPath);

        public void UpdateProfessor(Professor professor);

        public void DeleteProfessor(int id);

        public List<Professor> SearchProfessors(Search search);

        public void UploadProfilePhoto(int professorId, string photoPath);
    }
}
