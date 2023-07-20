﻿using AutoMapper;
using RateForProfessor.Entities;
using RateForProfessor.Models;
using RateForProfessor.Repositories.Interfaces;
using RateForProfessor.Services.Interfaces;

namespace RateForProfessor.Services
{
    public class UniversityService : IUniversityService
    {
        private readonly IUniversityRepository _universityRepository;
        private readonly IMapper _mapper;
        public UniversityService(IUniversityRepository universityRepository, IMapper mapper)
        {
            _universityRepository = universityRepository;
            _mapper = mapper;
        }
        public University CreateUniversitiy(University university)
        {
            try
            {
                var universityEntity = _mapper.Map<UniversityEntity>(university);
                var result = _universityRepository.CreateUniversity(universityEntity);
                var universityCreated = _mapper.Map<University>(result);
                return universityCreated;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void DeleteUniversity(int id)
        {
            _universityRepository.DeleteUniversity(id);
            var universiteti = _universityRepository.GetUniversityById(id);
        }

        public List<University> GetAllUniversites()
        {
            var universityEntities = _universityRepository.GetAllUniversites();
            var universities = _mapper.Map<List<University>>(universityEntities);
            return universities;
        }

        public University GetUniversityById(int id)
        {
            var universityEntity = _universityRepository.GetUniversityById(id);
            var university = _mapper.Map<University>(universityEntity);
            return university;
        }
        public University GetUniversityByName(string name)
        {
            var universityEntity = _universityRepository.GetUniversityByName(name);
            var university = _mapper.Map<University>(universityEntity);
            return university;
        }

        public void UpdateUniversity(University university)
        {
            var universityId = university.UniversityId;
            var existingUniversityEntity = _universityRepository.GetUniversityById(universityId);
            if(existingUniversityEntity == null)
            {
                throw new Exception("University not Found!");
            }
            var updateUniversity = _mapper.Map<UniversityEntity>(university);
            _universityRepository.UpdateUniversity(updateUniversity);
        }
    }
}