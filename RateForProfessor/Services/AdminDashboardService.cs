using AutoMapper;
using RateForProfessor.Entities;
using RateForProfessor.Models;
using RateForProfessor.Repositories.Interfaces;
using RateForProfessor.Services.Interfaces;

namespace RateForProfessor.Services
{
    public class AdminDashboardService : IAdminDashboardService
    {
        private readonly IProfessorRepository _professorRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IUserRegistrationRepository _userRegistrationRepository;
        private readonly IRateProfessorRepository _rateProfessorRepository;
        private readonly IRateUniversityRepository _rateUniversityRepository;
        private readonly IUniversityRepository _universityRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public AdminDashboardService(IProfessorRepository professorRepository, IDepartmentRepository departmentRepository, 
            IUserRegistrationRepository userRegistrationRepository, IRateProfessorRepository rateProfessorRepository,
            IRateUniversityRepository rateUniversityRepository, IUniversityRepository universityRepository, ICourseRepository courseRepository, IMapper mapper)
        {
            _professorRepository = professorRepository;
            _departmentRepository = departmentRepository;
            _userRegistrationRepository = userRegistrationRepository;
            _rateProfessorRepository = rateProfessorRepository;
            _rateUniversityRepository = rateUniversityRepository;
            _universityRepository = universityRepository;
            _courseRepository = courseRepository;
            _mapper = mapper;
        }


        public int GetDepartmentCount()
        {
            var countDepartment = _departmentRepository.GetAllDepartments().Count();
            return countDepartment;
        }
        public RateProfessor SortFromHighestRatedProfessor()
        {
            var sortedEntity = _rateProfessorRepository.GetAllRateProfessors().OrderByDescending(rp => rp.Overall);
            var highestRatedProfessor = sortedEntity.FirstOrDefault();
            var highestRatedProfessorDto = _mapper.Map<RateProfessor>(highestRatedProfessor);
            return highestRatedProfessorDto;
        }
        public RateUniversity GetHighestRatedUniversity()
        {
            var highestRatedUniversityEntity = _rateUniversityRepository.GetAllRateUniversity().MaxBy(ru => ru.Overall);
            var highestRatedUniversity = _mapper.Map<RateUniversity>(highestRatedUniversityEntity);
            return highestRatedUniversity;
        }
        public University GetOldestUniversity()
        {
            var oldestUniversityEntity = _universityRepository.GetAllUniversites().Min(u => u.EstablishedYear);
            var oldestUniversity = _mapper.Map<University>(oldestUniversityEntity);
            return oldestUniversity;
        }
        public int GetProfessorCount()
        {
            var count = _professorRepository.GetAllProfessors().Count();
            return count;
        }
        public int GetStudentCount()
        {
            var count = _userRegistrationRepository.GetAllStudents().Count();
            return count;
        }
        public int GetUniversityCount()
        {
            //var count = _universityRepository.GetAllUniversity().Count();
            //return count;
            throw new NotImplementedException();
        }
    }
}
