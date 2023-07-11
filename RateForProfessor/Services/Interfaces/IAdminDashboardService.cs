using RateForProfessor.Models;

namespace RateForProfessor.Services.Interfaces
{
    public interface IAdminDashboardService
    {
        //Proffessor
        public List<Professor> GetAllProfessors();
        public Professor GetProfessorById(int id);
        //Krijimi i logjikes 
        public Professor GetProfessorByName(string name);
        
        public Professor CreateProfessor(Professor professor);
        public void UpdateProfessor(Professor professor);
        public void DeleteProfessor(int id);
        //Department
        public List<Department> GetAllDepartments();
        public Department GetDepartmentById(int id);
        //Krijimi i logjikes
        public Department GetDepartmentByName(string name);
        
        
        public Department CreateDepartment(Department department);
        public void UpdateDepartment(Department department);
        public void DeleteDepartment(int id);
        //Student
        public List<Student> GetAllStudents();
        public Student GetStudentById(int id);
        public Student GetStudentByEmail(string email);
        //Krijimi i logjikes
        public Student GetStudentByName(string name);
        
        
        //public Student CreateStudent(Student student);
        //public void UpdateStudent(Student student);
        public void DeleteStudent(int id);
        //University
        public List<University> GetAllUniversites();
        public University GetUniversityById(int id);
        public University GetUniversityByName(string name);
        //Krijimi i logjikes
        
        public University CreateUniversitiy(University university);
        public void UpdateUniversity(University university);
        public void DeleteUniversity(int id);
        //Statistikat
        public int GetUniversityCount();
        public int GetStudentCount();
        public int GetDepartmentCount();
        public int GetProfessorCount();
        public List<RateProfessor> SortFromHighestRatedProfessor();
        public RateUniversity GetHighestRatedUniversity();
        public University GetOldestUniversity();

    }
}
