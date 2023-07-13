using AutoMapper;
using RateForProfessor.Entities;
using RateForProfessor.Models;
using RateForProfessor.Repositories.Interfaces;
using RateForProfessor.Services.Interfaces;

namespace RateForProfessor.Services
{
    public class RateUniversityService : IRateUniversityService
    {
        public readonly IRateUniversityRepository _rateUniversityRepository;
        private readonly IMapper _mapper;

        public RateUniversityService(IRateUniversityRepository rateUniversityRepository, IMapper mapper)
        {
            _rateUniversityRepository = rateUniversityRepository;
            _mapper = mapper;
        }

        public RateUniversity CreateRateUniversity(RateUniversity rateUniversity)
        {
            try
            {
                var rateEntity = _mapper.Map<RateUniversityEntity>(rateUniversity);
                var result = _rateUniversityRepository.CreateRateUniversity(rateEntity);

                var rateCreated = _mapper.Map<RateUniversity>(result);
                return rateCreated;

            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteRateUniversity(int id)
        {
            _rateUniversityRepository.DeleteRateUniversity(id);
        }

        public List<RateUniversity> GetAllRateUniversity()
        {
            var rateUniversityEntities = _rateUniversityRepository.GetAllRateUniversity();
            var rateUniversity = _mapper.Map<List<RateUniversity>>(rateUniversityEntities);
            return rateUniversity;
        }

        public RateUniversity GetRateUniversityById(int id)
        {
            var rateEntity = _rateUniversityRepository.GetRateUniversityById(id);
            var rateUniversity = _mapper.Map<RateUniversity>(rateEntity);
            return rateUniversity;
        }
        public List<RateUniversity> GetRateUniversityByUniversiyId(int universityId)
        {
            var rateUniversity = _rateUniversityRepository.GetRateUniversitysByUniversityId(universityId);
            return _mapper.Map<List<RateUniversity>>(rateUniversity);
        }

        public List<RateUniversity> GetRateUniversityByStudentId(int studentId)
        {
            var rateUniversity = _rateUniversityRepository.GetRateUniversityByStudentId(studentId);
            return _mapper.Map<List<RateUniversity>>(rateUniversity);
        }

        public void UpdateRateUniversity(RateUniversity rateUniversity)
        {
            var existingRateUniversityEntity = _rateUniversityRepository.GetRateUniversityById(rateUniversity.Id);

            if (existingRateUniversityEntity == null)
            {
                throw new Exception("Rate University not found");
            }
            var updatedRateUniversity = _mapper.Map<RateUniversityEntity>(rateUniversity);

            _rateUniversityRepository.UpdateRateUniversity(updatedRateUniversity);
        }
    }
}
