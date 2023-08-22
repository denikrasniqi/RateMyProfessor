using RateForProfessor.Context;
using RateForProfessor.Entities;
using RateForProfessor.Repositories.Interfaces;

namespace RateForProfessor.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _dbContext;

        public DepartmentRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public DepartmentEntity CreateDepartment(DepartmentEntity department)
        {
            _dbContext.Departments.Add(department);
            _dbContext.SaveChanges();
            return department;
        }

        public List<DepartmentEntity> GetAllDepartments()
        {
            return _dbContext.Departments.ToList();
        }

        public DepartmentEntity GetDepartmentById(int id)
        {
            return _dbContext.Departments.Find(id);
        }

        public List<DepartmentEntity> GetDepartmentsByUniversity(int universityId)
        {
            return _dbContext.Departments.Where(x => x.UniversityId == universityId).ToList();
        }
        public void UpdateDepartment(DepartmentEntity department)
        {
            var olddepartment = _dbContext.Departments.Find(department.DepartmentId);
            _dbContext.Entry(olddepartment).CurrentValues.SetValues(department);
            _dbContext.SaveChanges();
        }
        public void DeleteDepartment(int id)
        {
            var department = _dbContext.Departments.Find(id);
            _dbContext.Departments.Remove(department);
            _dbContext.SaveChanges();
        }

        public DepartmentEntity GetDepartmentByName(string name)
        {
            var department = _dbContext.Departments.FirstOrDefault(d => d.Name == name);
            return department;
        }
    }
}
