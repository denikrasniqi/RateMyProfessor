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

            modelBuilder.Entity<AddressEntity>()
               .HasKey(pk => new { pk.AddressId });

            modelBuilder.Entity<AddressEntity>()
                .HasOne(ae => ae.Universities)
                .WithMany(ae => ae.Addresses)
                .HasForeignKey(fk => fk.UniversityId);

            modelBuilder.Entity<ContactNumberEntity>()
               .HasKey(pk => new { pk.ContactNumberId });

            modelBuilder.Entity<ContactNumberEntity>()
                .HasOne(ae => ae.Universities)
                .WithMany(ae => ae.ContactNumbers)
                .HasForeignKey(fk => fk.UniversityId);

            modelBuilder.Entity<CourseEntity>()
               .HasKey(pk => new { pk.ID });

            modelBuilder.Entity<CourseEntity>()
                .HasOne(ae => ae.Departments)
                .WithMany(ae => ae.Courses)
                .HasForeignKey(fk => fk.UniversityId);

            modelBuilder.Entity<DepartmentProfessorEntity>()
               .HasKey(pk => new { pk.DepartmentId });

            modelBuilder.Entity<DepartmentProfessorEntity>()
                .HasOne(ae => ae.Departments)
                .WithMany(ae => ae.DepartmentProfessors)
                .HasForeignKey(fk => fk.DepartmentId);

            modelBuilder.Entity<DepartmentProfessorEntity>()
                .HasOne(ae => ae.Profesors)
                .WithMany(ae => ae.DepartmentProfessors)
                .HasForeignKey(fk => fk.ProfessorId);

            modelBuilder.Entity<ProfessorCourseEntity>()
              .HasKey(pk => new { pk.ProfessorCourseId });

            modelBuilder.Entity<ProfessorCourseEntity>()
                .HasOne(ae => ae.Profesors)
                .WithMany(ae => ae.ProfessorCourses)
                .HasForeignKey(fk => fk.ProfessorId);

            modelBuilder.Entity<ProfessorCourseEntity>()
                .HasOne(ae => ae.Courses)
                .WithMany(ae => ae.ProfessorCourses)
                .HasForeignKey(fk => fk.CourseId);

            modelBuilder.Entity<StudentEntity>()
               .HasKey(pk => new { pk.ID });

            modelBuilder.Entity<StudentEntity>()
                .HasOne(ae => ae.DepartmentEntity)
                .WithMany(ae => ae.Students)
                .HasForeignKey(fk => fk.DepartmentID);

            modelBuilder.Entity<DepartmentEntity>()
              .HasKey(pk => new { pk.DepartmentID });

            modelBuilder.Entity<DepartmentEntity>()
                .HasOne(ae => ae.Universities)
                .WithMany(ae => ae.Departments)
                .HasForeignKey(fk => fk.UniversityId);

            modelBuilder.Entity<ProfessorEntity>()
              .HasKey(pk => new { pk.ProfessorId });

            modelBuilder.Entity<RateProfessorEntity>()
             .HasKey(pk => new { pk.Id });

            modelBuilder.Entity<RateProfessorEntity>()
                .HasOne(ae => ae.Profesors)
                .WithMany(ae => ae.RateProfessors)
                .HasForeignKey(fk => fk.ProfessorId);

            modelBuilder.Entity<RateProfessorEntity>()
                .HasOne(ae => ae.Students)
                .WithMany(ae => ae.RateProfessors)
                .HasForeignKey(fk => fk.ID);

            modelBuilder.Entity<RateUniversityEntity>()
             .HasKey(pk => new { pk.Id });

            modelBuilder.Entity<RateUniversityEntity>()
                .HasOne(ae => ae.Universities)
                .WithMany(ae => ae.RateUniversities)
                .HasForeignKey(fk => fk.UniversityId);

            modelBuilder.Entity<RateUniversityEntity>()
                .HasOne(ae => ae.Students)
                .WithOne(ae => ae.RateUniversities)
                .HasForeignKey(fk => fk.StudentId);

            modelBuilder.Entity<UniversityEntity>()
             .HasKey(pk => new { pk.Id });
        }
    }
}
