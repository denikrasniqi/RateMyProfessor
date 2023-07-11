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
        //private readonly IRateUniversityRepository _rateUniversityRepository;
        //private readonly IUniversityRepository _universityRepository;
        private readonly IMapper _mapper;

        public AdminDashboardService(IProfessorRepository professorRepository, IDepartmentRepository departmentRepository, 
            IUserRegistrationRepository userRegistrationRepository, IRateProfessorRepository rateProfessorRepository,
            /*IRateUniversityRepository rateUniversityRepository*//*, IUniversityRepository universityRepository,*/ IMapper mapper)
        {
            _professorRepository = professorRepository;
            _departmentRepository = departmentRepository;
            _userRegistrationRepository = userRegistrationRepository;
            _rateProfessorRepository = rateProfessorRepository;
            //_rateUniversityRepository = rateUniversityRepository;
            //_universityRepository = universityRepository;
            _mapper = mapper;
        }

        public Department CreateDepartment(Department department)
        {
            try
            {
                var departmentEntity = _mapper.Map<DepartmentEntity>(department);
                var result = _departmentRepository.CreateDepartment(departmentEntity);
                var departmentCreated = _mapper.Map<Department>(result);
                return departmentCreated;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Professor CreateProfessor(Professor professor)
        {
            try
            {
                var professorEntity = _mapper.Map<ProfessorEntity>(professor);
                var result = _professorRepository.CreateProfessor(professorEntity);
                var professorCreated = _mapper.Map<Professor>(result);
                return professorCreated;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public University CreateUniversitiy(University university)
        {
            //try
            //{
            //    var universityEntity = _mapper.Map<UniversityEntity>(university);
            //    var result = _universityRepository.CreateUniversity(universityEntity);
            //    var universityCreated = _mapper.Map<University>(result);
            //    return universityCreated;
            //}
            //catch (Exception ex)
            //{

            //    throw new Exception(ex.Message);
            //}
            throw new NotImplementedException();
        }

        public void DeleteDepartment(int id)
        {
            _departmentRepository.DeleteDepartment(id);
        }

        public void DeleteProfessor(int id)
        {
            _professorRepository.DeleteProfessor(id);
        }

        public void DeleteStudent(int id)
        {
            _userRegistrationRepository.DeleteStudent(id);
        }

        public void DeleteUniversity(int id)
        {
            //_universityRepository.DeleteUniversity(id);
            throw new NotImplementedException();
        }

        public List<Department> GetAllDepartments()
        {
            var departmentEntities = _departmentRepository.GetAllDepartments();
            var departments = _mapper.Map<List<Department>>(departmentEntities);
            return departments;
        }

        public List<Professor> GetAllProfessors()
        {
            var professorEntities = _professorRepository.GetAllProfessors();
            var professors = _mapper.Map<List<Professor>>(professorEntities);
            return professors;
        }

        public List<Student> GetAllStudents()
        {
            var studentEntities = _userRegistrationRepository.GetAllStudents();
            var students = _mapper.Map<List<Student>>(studentEntities);
            return students;
        }

        public List<University> GetAllUniversites()
        {
            //var universityEntities = _universityRepository.GetAllUniversities();
            //var universities = _mapper.Map<List<University>>(universityEntities);
            //return universities;
            throw new NotImplementedException();
        }

        public Department GetDepartmentById(int id)
        {
            var departmentEntity = _departmentRepository.GetDepartmentById(id);
            var department = _mapper.Map<Department>(departmentEntity);
            return department;
        }

        public Department GetDepartmentByName(string name)
        {
            var departmentEntity = _departmentRepository.GetDepartmentByName(name);
            var department = _mapper.Map<Department>(departmentEntity);
            return department;
        }

        public int GetDepartmentCount()
        {
            var countDepartment = _departmentRepository.GetAllDepartments().Count();
            return countDepartment;
        }

        public List<RateProfessor> SortFromHighestRatedProfessor()
        { 
            var sortedEntity = _rateProfessorRepository.GetAllRateProfessors().OrderByDescending(rp => rp.Overall);
            var sorted = _mapper.Map<List<RateProfessor>>(sortedEntity);
            return sorted;
        }

        public RateUniversity GetHighestRatedUniversity()
        {
            //var highestRatedUniversityEntity = _rateUniversityRepository.GetAllRateUniversity().MaxBy(ru => ru.Overall);
            //var highestRatedUniversity = _mapper.Map<RateUniversity>(highestRatedUniversityEntity);
            //return highestRatedUniversity;
            throw new NotImplementedException();
        }

        public University GetOldestUniversity()
        {
            //var oldestUniversityEntity = _universityRepository.GetAllUniversity().Min(u => u.EstablishedYear);
            //var oldestUniversity = _mapper.Map<University>(oldestUniversityEntity);
            //return oldestUniversity;
            throw new NotImplementedException();
        }

        public Professor GetProfessorById(int id)
        {
            var professorEntity = _professorRepository.GetProfessorById(id);
            var professor = _mapper.Map<Professor>(professorEntity);
            return professor;
        }

        public Professor GetProfessorByName(string name)
        {
            var professorEntity = _professorRepository.GetProfessorByName(name);
            var professor = _mapper.Map<Professor>(professorEntity);
            return professor;
        }

        public int GetProfessorCount()
        {
            var count = _professorRepository.GetAllProfessors().Count();
            return count;
        }

        public Student GetStudentByEmail(string email)
        {
            var studentEntity = _userRegistrationRepository.GetStudentByEmail(email);
            var student = _mapper.Map<Student>(studentEntity);
            return student;
        }

        public Student GetStudentById(int id)
        {
            var studentEntity = _userRegistrationRepository.GetStudentById(id);
            var student = _mapper.Map<Student>(studentEntity);
            return student;
        }

        public Student GetStudentByName(string name)
        {
            var studentEntity = _userRegistrationRepository.GetStudentByName(name);
            var student = _mapper.Map<Student>(studentEntity);
            return student;
        }

        public int GetStudentCount()
        {
            var count = _userRegistrationRepository.GetAllStudents().Count();
            return count;
        }

        public University GetUniversityById(int id)
        {
            //var universityEntity = _universityRepository.GetUniversityById(id);
            //var university = _mapper.Map<University>(universityEntity);
            //return university;
            throw new NotImplementedException();
        }

        public University GetUniversityByName(string name)
        {
            //var universityEntity = _universityRepository.GetUniversityByName(name);
            //var university = _mapper.Map<University>(universityEntity);
            //return university;
            throw new NotImplementedException();
        }

        public int GetUniversityCount()
        {
            //var count = _universityRepository.GetAllUniversity().Count();
            //return count;
            throw new NotImplementedException();
        }

        public void UpdateDepartment(Department department)
        {
            var existingDepartmentEntity = _departmentRepository.GetDepartmentById(department.DepartmentId);

            if (existingDepartmentEntity == null)
            {
                throw new Exception("Department not found");
            }
            var updatedDepartment = _mapper.Map<DepartmentEntity>(department);

            _departmentRepository.UpdateDepartment(updatedDepartment);
        }

        public void UpdateProfessor(Professor professor)
        {
            var existingProfessorEntity = _professorRepository.GetProfessorById(professor.ProfessorId);

            if (existingProfessorEntity == null)
            {
                throw new Exception("Professor not found");
            }
            var updatedProfessor = _mapper.Map<ProfessorEntity>(professor);

            _professorRepository.UpdateProfessor(updatedProfessor);
        }

        public void UpdateUniversity(University university)
        {
            //var universityId = university.UniversityId;
            //var existingUniversityEntity = _universityRepository.GetUniversityById(universityId);
            //if (existingUniversityEntity == null)
            //{
            //    throw new Exception("University not Found!");
            //}
            //var updateUniversity = _mapper.Map<UniversityEntity>(university);
            //_universityRepository.UpdateUniversity(updateUniversity);
            throw new NotImplementedException();
        }
    }
}
