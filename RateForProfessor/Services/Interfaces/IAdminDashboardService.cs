using RateForProfessor.Models;

namespace RateForProfessor.Services.Interfaces
{
    public interface IAdminDashboardService
    {
        public int GetUniversityCount();
        public int GetStudentCount();
        public int GetDepartmentCount();
        public int GetProfessorCount();
        public RateProfessor SortFromHighestRatedProfessor();
        public RateUniversity GetHighestRatedUniversity();
        public University GetOldestUniversity();
    }
}
