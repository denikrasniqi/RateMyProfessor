using Microsoft.EntityFrameworkCore;
using RateForProfessor.Entities;

namespace RateForProfessor.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<AddressEntity> Addresses { get; set; }
        public DbSet<ContactNumberEntity> ContactNumbers { get; set; }
        public DbSet<CourseEntity> Courses { get; set; }
        public DbSet<DepartmentEntity> Departments { get; set; }
        public DbSet<DepartmentProfessorEntity> DepartmentProfessors { get; set; }
        public DbSet<ProfessorCourseEntity> ProfessorCourses { get; set; }
        public DbSet<ProfessorEntity> Profesors { get; set; }
        public DbSet<RateProfessorEntity> RateProfessors { get; set; }
        public DbSet<RateUniversityEntity> RateUniversities { get; set; }
        public DbSet<StudentEntity> Students { get; set; }
        public DbSet<UniversityEntity> Universities { get; set; }
        
        
        
        


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
