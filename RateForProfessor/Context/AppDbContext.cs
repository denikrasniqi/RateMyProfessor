using Microsoft.EntityFrameworkCore;
using RateForProfessor.Entities;
using RateForProfessor.Models;

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
        public DbSet<UserEntity> Users { get; set; }
 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AddressEntity>().ToTable("Addresses");
            modelBuilder.Entity<ContactNumberEntity>().ToTable("ContactNumbers");
            modelBuilder.Entity<CourseEntity>().ToTable("Courses");
            modelBuilder.Entity<DepartmentEntity>().ToTable("Departments");
            modelBuilder.Entity<DepartmentProfessorEntity>().ToTable("DepartmentProfessors");
            modelBuilder.Entity<ProfessorCourseEntity>().ToTable("ProfessorCourses");
            modelBuilder.Entity<ProfessorEntity>().ToTable("Profesors");
            modelBuilder.Entity<RateProfessorEntity>().ToTable("RateProfessors");
            modelBuilder.Entity<RateUniversityEntity>().ToTable("RateUniversities");
            modelBuilder.Entity<StudentEntity>().ToTable("Students");
            modelBuilder.Entity<UniversityEntity>().ToTable("Universities");
            modelBuilder.Entity<UserEntity>().ToTable("Users");

            modelBuilder.Entity<AddressEntity>()
               .HasKey(pk => new { pk.AddressId });

            modelBuilder.Entity<AddressEntity>()
                .HasOne(ae => ae.University)
                .WithMany(ae => ae.Addresses)
                .HasForeignKey(fk => fk.UniversityId);

            modelBuilder.Entity<ContactNumberEntity>()
               .HasKey(pk => new { pk.ContactNumberId });

            modelBuilder.Entity<ContactNumberEntity>()
                .HasOne(ae => ae.University)
                .WithMany(ae => ae.ContactNumbers)
                .HasForeignKey(fk => fk.UniversityId);

            modelBuilder.Entity<CourseEntity>()
               .HasKey(pk => new { pk.ID });

            modelBuilder.Entity<CourseEntity>()
                .HasOne(ae => ae.Department)
                .WithMany(c => c.Courses)
                .HasForeignKey(ae => ae.DepartmentID);

            modelBuilder.Entity<DepartmentProfessorEntity>()
               .HasKey(pk => new { pk.DepartmentId });

            modelBuilder.Entity<DepartmentProfessorEntity>()
                .HasOne(dp => dp.Department)
                .WithMany(ae => ae.DepartmentProfessors)
                .HasForeignKey(dp => dp.DepartmentId);

            modelBuilder.Entity<DepartmentProfessorEntity>()
                .HasOne(ae => ae.Professor)
                .WithMany(ae => ae.DepartmentProfessors)
                .HasForeignKey(fk => fk.ProfessorId);

            modelBuilder.Entity<ProfessorCourseEntity>()
              .HasKey(pk => new { pk.ProfessorCourseId });

            modelBuilder.Entity<ProfessorCourseEntity>()
                .HasOne(ae => ae.Professor)
                .WithMany(ae => ae.ProfessorCourses)
                .HasForeignKey(fk => fk.ProfessorId);

            modelBuilder.Entity<ProfessorCourseEntity>()
                .HasOne(ae => ae.Courses)
                .WithMany(ae => ae.ProfessorCourses)
                .HasForeignKey(fk => fk.CourseId);

            modelBuilder.Entity<StudentEntity>()
               .HasKey(pk => new { pk.StudentId });

            modelBuilder.Entity<StudentEntity>()
                .HasOne(s => s.University)
                .WithMany(s => s.Students)
                .HasForeignKey(fk => fk.UniversityId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<StudentEntity>()
                .HasOne(ae => ae.Department)
                .WithMany(ae => ae.Students)
                .HasForeignKey(fk => fk.DepartmentID);

            //modelBuilder.Entity<StudentEntity>()
            //    .HasOne(s => s.User)
            //    .WithOne(s => s.Student)
            //    .HasForeignKey(fk => fk.UserId);

            modelBuilder.Entity<StudentEntity>()
            .HasOne(s => s.User)
            .WithOne()
            .HasForeignKey<StudentEntity>(s => s.UserId);

            modelBuilder.Entity<UserEntity>()
                .HasKey(u => new { u.UserId });

            modelBuilder.Entity<DepartmentEntity>()
              .HasKey(pk => new { pk.DepartmentId });

            modelBuilder.Entity<DepartmentEntity>()
                .HasOne(ae => ae.University)
                .WithMany(ae => ae.Departments)
                .HasForeignKey(fk => fk.UniversityId);

            modelBuilder.Entity<ProfessorEntity>()
              .HasKey(pk => new { pk.ProfessorId });

            modelBuilder.Entity<RateProfessorEntity>()
             .HasKey(pk => new { pk.Id });

            modelBuilder.Entity<RateProfessorEntity>()
                .HasOne(ae => ae.Professor)
                .WithMany(ae => ae.RateProfessors)
                .HasForeignKey(fk => fk.ProfessorId);

            modelBuilder.Entity<RateProfessorEntity>()
                .HasOne(ae => ae.Student)
                .WithMany(ae => ae.RateProfessors)
                .HasForeignKey(fk => fk.StudentId);


            modelBuilder.Entity<RateUniversityEntity>()
             .HasKey(pk => new { pk.Id });

            modelBuilder.Entity<RateUniversityEntity>()
                .HasOne(ae => ae.University)
                .WithMany(ae => ae.RateUniversities)
                .HasForeignKey(fk => fk.UniversityId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<RateUniversityEntity>()
                .HasOne(ae => ae.Student)
                .WithOne(ae => ae.RateUniversity)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UniversityEntity>()
             .HasKey(pk => new { pk.UniversityId });
        }
    }
}
