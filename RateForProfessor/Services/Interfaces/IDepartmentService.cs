using RateForProfessor.Models;

namespace RateForProfessor.Services.Interfaces
{
    public interface IDepartmentService
    {
        public List<Department> GetAllDepartments();

        public Department GetDepartmentById(int id);

        public Department CreateDepartment(Department department);

        public void UpdateDepartment(Department department);

        public void DeleteDepartment(int id);

        public Department GetDepartmentByName(string name);
    }
}
