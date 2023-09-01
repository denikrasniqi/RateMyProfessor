﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RateForProfessor.Context;

#nullable disable

namespace RateForProfessor.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("RateForProfessor.Entities.AddressEntity", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AddressId"), 1L, 1);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UniversityId")
                        .HasColumnType("int");

                    b.Property<int>("ZIPCode")
                        .HasColumnType("int");

                    b.HasKey("AddressId");

                    b.HasIndex("UniversityId");

                    b.ToTable("Addresses", (string)null);
                });

            modelBuilder.Entity("RateForProfessor.Entities.ContactNumberEntity", b =>
                {
                    b.Property<int>("ContactNumberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContactNumberId"), 1L, 1);

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UniversityId")
                        .HasColumnType("int");

                    b.HasKey("ContactNumberId");

                    b.HasIndex("UniversityId");

                    b.ToTable("ContactNumbers", (string)null);
                });

            modelBuilder.Entity("RateForProfessor.Entities.CourseEntity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CreditHours")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("DepartmentID");

                    b.ToTable("Courses", (string)null);
                });

            modelBuilder.Entity("RateForProfessor.Entities.DepartmentEntity", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmentId"), 1L, 1);

                    b.Property<int>("CourseNumber")
                        .HasColumnType("int");

                    b.Property<int?>("DepartmentProfessorEntityDepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EstablishedYear")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StaffNumber")
                        .HasColumnType("int");

                    b.Property<int>("StudentNumber")
                        .HasColumnType("int");

                    b.Property<int>("UniversityId")
                        .HasColumnType("int");

                    b.HasKey("DepartmentId");

                    b.HasIndex("DepartmentProfessorEntityDepartmentId");

                    b.HasIndex("UniversityId");

                    b.ToTable("Departments", (string)null);
                });

            modelBuilder.Entity("RateForProfessor.Entities.DepartmentProfessorEntity", b =>
                {
                    b.Property<int>("DepartmentId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<int>("ProfessorId")
                        .HasColumnType("int")
                        .HasColumnOrder(2);

                    b.HasKey("DepartmentId");

                    b.HasIndex("ProfessorId");

                    b.ToTable("DepartmentProfessors", (string)null);
                });

            modelBuilder.Entity("RateForProfessor.Entities.NewsEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePhotoPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PublicationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("News", (string)null);
                });

            modelBuilder.Entity("RateForProfessor.Entities.ProfessorCourseEntity", b =>
                {
                    b.Property<int>("ProfessorCourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProfessorCourseId"), 1L, 1);

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("ProfessorId")
                        .HasColumnType("int");

                    b.HasKey("ProfessorCourseId");

                    b.HasIndex("CourseId");

                    b.HasIndex("ProfessorId");

                    b.ToTable("ProfessorCourses", (string)null);
                });

            modelBuilder.Entity("RateForProfessor.Entities.ProfessorEntity", b =>
                {
                    b.Property<int>("ProfessorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProfessorId"), 1L, 1);

                    b.Property<int?>("DepartmentProfessorEntityDepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Education")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePhotoPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProfessorId");

                    b.HasIndex("DepartmentProfessorEntityDepartmentId");

                    b.ToTable("Profesors", (string)null);
                });

            modelBuilder.Entity("RateForProfessor.Entities.RateProfessorEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CommunicationSkills")
                        .HasColumnType("int");

                    b.Property<string>("Feedback")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GradingFairness")
                        .HasColumnType("int");

                    b.Property<int>("Overall")
                        .HasColumnType("int");

                    b.Property<int>("ProfessorId")
                        .HasColumnType("int");

                    b.Property<int>("Responsiveness")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProfessorId");

                    b.HasIndex("StudentId");

                    b.ToTable("RateProfessors", (string)null);
                });

            modelBuilder.Entity("RateForProfessor.Entities.RateUniversityEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Feedback")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Overall")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("UniversityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StudentId")
                        .IsUnique();

                    b.HasIndex("UniversityId");

                    b.ToTable("RateUniversities", (string)null);
                });

            modelBuilder.Entity("RateForProfessor.Entities.StudentEntity", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentId"), 1L, 1);

                    b.Property<int>("DepartmentID")
                        .HasColumnType("int");

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.Property<string>("ProfilePhotoPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UniversityId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("StudentId");

                    b.HasIndex("DepartmentID");

                    b.HasIndex("UniversityId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Students", (string)null);
                });

            modelBuilder.Entity("RateForProfessor.Entities.UniversityEntity", b =>
                {
                    b.Property<int>("UniversityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UniversityId"), 1L, 1);

                    b.Property<int>("CoursesNumber")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EstablishedYear")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePhotoPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StaffNumber")
                        .HasColumnType("int");

                    b.Property<int>("StudentsNumber")
                        .HasColumnType("int");

                    b.HasKey("UniversityId");

                    b.ToTable("Universities", (string)null);
                });

            modelBuilder.Entity("RateForProfessor.Entities.UserEntity", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("RateForProfessor.Entities.AddressEntity", b =>
                {
                    b.HasOne("RateForProfessor.Entities.UniversityEntity", "University")
                        .WithMany("Addresses")
                        .HasForeignKey("UniversityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("University");
                });

            modelBuilder.Entity("RateForProfessor.Entities.ContactNumberEntity", b =>
                {
                    b.HasOne("RateForProfessor.Entities.UniversityEntity", "University")
                        .WithMany("ContactNumbers")
                        .HasForeignKey("UniversityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("University");
                });

            modelBuilder.Entity("RateForProfessor.Entities.CourseEntity", b =>
                {
                    b.HasOne("RateForProfessor.Entities.DepartmentEntity", "Department")
                        .WithMany("Courses")
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("RateForProfessor.Entities.DepartmentEntity", b =>
                {
                    b.HasOne("RateForProfessor.Entities.DepartmentProfessorEntity", null)
                        .WithMany("Departments")
                        .HasForeignKey("DepartmentProfessorEntityDepartmentId");

                    b.HasOne("RateForProfessor.Entities.UniversityEntity", "University")
                        .WithMany("Departments")
                        .HasForeignKey("UniversityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("University");
                });

            modelBuilder.Entity("RateForProfessor.Entities.DepartmentProfessorEntity", b =>
                {
                    b.HasOne("RateForProfessor.Entities.DepartmentEntity", "Department")
                        .WithMany("DepartmentProfessors")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RateForProfessor.Entities.ProfessorEntity", "Professor")
                        .WithMany("DepartmentProfessors")
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Professor");
                });

            modelBuilder.Entity("RateForProfessor.Entities.ProfessorCourseEntity", b =>
                {
                    b.HasOne("RateForProfessor.Entities.CourseEntity", "Courses")
                        .WithMany("ProfessorCourses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RateForProfessor.Entities.ProfessorEntity", "Professor")
                        .WithMany("ProfessorCourses")
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Courses");

                    b.Navigation("Professor");
                });

            modelBuilder.Entity("RateForProfessor.Entities.ProfessorEntity", b =>
                {
                    b.HasOne("RateForProfessor.Entities.DepartmentProfessorEntity", null)
                        .WithMany("Professors")
                        .HasForeignKey("DepartmentProfessorEntityDepartmentId");
                });

            modelBuilder.Entity("RateForProfessor.Entities.RateProfessorEntity", b =>
                {
                    b.HasOne("RateForProfessor.Entities.ProfessorEntity", "Professor")
                        .WithMany("RateProfessors")
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RateForProfessor.Entities.StudentEntity", "Student")
                        .WithMany("RateProfessors")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Professor");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("RateForProfessor.Entities.RateUniversityEntity", b =>
                {
                    b.HasOne("RateForProfessor.Entities.StudentEntity", "Student")
                        .WithOne("RateUniversity")
                        .HasForeignKey("RateForProfessor.Entities.RateUniversityEntity", "StudentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("RateForProfessor.Entities.UniversityEntity", "University")
                        .WithMany("RateUniversities")
                        .HasForeignKey("UniversityId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("University");
                });

            modelBuilder.Entity("RateForProfessor.Entities.StudentEntity", b =>
                {
                    b.HasOne("RateForProfessor.Entities.DepartmentEntity", "Department")
                        .WithMany("Students")
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RateForProfessor.Entities.UniversityEntity", "University")
                        .WithMany("Students")
                        .HasForeignKey("UniversityId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("RateForProfessor.Entities.UserEntity", "User")
                        .WithOne()
                        .HasForeignKey("RateForProfessor.Entities.StudentEntity", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("University");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RateForProfessor.Entities.CourseEntity", b =>
                {
                    b.Navigation("ProfessorCourses");
                });

            modelBuilder.Entity("RateForProfessor.Entities.DepartmentEntity", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("DepartmentProfessors");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("RateForProfessor.Entities.DepartmentProfessorEntity", b =>
                {
                    b.Navigation("Departments");

                    b.Navigation("Professors");
                });

            modelBuilder.Entity("RateForProfessor.Entities.ProfessorEntity", b =>
                {
                    b.Navigation("DepartmentProfessors");

                    b.Navigation("ProfessorCourses");

                    b.Navigation("RateProfessors");
                });

            modelBuilder.Entity("RateForProfessor.Entities.StudentEntity", b =>
                {
                    b.Navigation("RateProfessors");

                    b.Navigation("RateUniversity")
                        .IsRequired();
                });

            modelBuilder.Entity("RateForProfessor.Entities.UniversityEntity", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("ContactNumbers");

                    b.Navigation("Departments");

                    b.Navigation("RateUniversities");

                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
