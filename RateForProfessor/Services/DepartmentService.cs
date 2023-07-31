using AutoMapper;
using RateForProfessor.Entities;
using RateForProfessor.Models;
using RateForProfessor.Repositories.Interfaces;
using RateForProfessor.Services.Interfaces;

namespace RateForProfessor.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public DepartmentService(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
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

        public void DeleteDepartment(int id)
        {
            _departmentRepository.DeleteDepartment(id);
        }

        public List<Department> GetAllDepartments()
        {
            var departmentEntities = _departmentRepository.GetAllDepartments();
            var departments = _mapper.Map<List<Department>>(departmentEntities);
            return departments;
        }

        public Department GetDepartmentById(int id)
        {
            var departmentEntity = _departmentRepository.GetDepartmentById(id);
            var department = _mapper.Map<Department>(departmentEntity);
            return department;
        }

        public List<Department> GetDepartmentsByUniversity(int universityId)
        {
            var departmentEntity = _departmentRepository.GetDepartmentsByUniversity(universityId);
            var departments = _mapper.Map<List<Department>>(departmentEntity);
            return departments;
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
        public Department GetDepartmentByName(string name)
        {
            var departmentEntity = _departmentRepository.GetDepartmentByName(name);
            var department = _mapper.Map<Department>(departmentEntity);
            return department;
        }
    }
}
