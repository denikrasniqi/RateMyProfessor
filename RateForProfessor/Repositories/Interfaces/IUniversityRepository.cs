﻿using RateForProfessor.Entities;

namespace RateForProfessor.Repositories.Interfaces
{
    public interface IUniversityRepository
    {
        public List<UniversityEntity> GetAllUniversites();

        public UniversityEntity GetUniversityById(int id);
        public UniversityEntity GetUniversityByName(string name);

        public UniversityEntity CreateUniversity(UniversityEntity university);

        public void UpdateUniversity (UniversityEntity university);

        public void DeleteUniversity(int id);
    }
}