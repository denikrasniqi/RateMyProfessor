using AutoMapper;
using RateForProfessor.Entities;
using RateForProfessor.Models;
using RateForProfessor.Repositories;
using RateForProfessor.Repositories.Interfaces;
using RateForProfessor.Services.Interfaces;

namespace RateForProfessor.Services
{
    public class UserRegistrationService : IUserRegistrationService
    {
        private readonly IUserRegistrationRepository _userRegistrationRepository;
        private readonly IMapper _mapper;

        public UserRegistrationService(IUserRegistrationRepository userRegistrationRepository, IMapper mapper)
        {
            _userRegistrationRepository = userRegistrationRepository;
            _mapper = mapper;
        }
        public Student CreateStudent(Student student)
        {
            try
            {
                var studentEntity = _mapper.Map<StudentEntity>(student);
                var result = _userRegistrationRepository.CreateStudent(studentEntity);

                var studentCreated = _mapper.Map<Student>(result);
                return studentCreated;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        public void DeleteStudent(int id)
        {
            _userRegistrationRepository.DeleteStudent(id);
        }

        public List<Student> GetAllStudents()
        {
            //return _userRegistrationRepository.GetAllStudents();
            var studentEntities = _userRegistrationRepository.GetAllStudents();
            var students = _mapper.Map<List<Student>>(studentEntities);
            return students;
        }

        public Student GetStudentByEmail(string email)
        {

            var studentEntity = _userRegistrationRepository.GetStudentByEmail(email);
            var student = _mapper.Map<Student>(studentEntity);
            return student;
        }
        public Student GetStudentByName(string name)
        {

            var studentEntity = _userRegistrationRepository.GetStudentByName(name);
            var student = _mapper.Map<Student>(studentEntity);
            return student;
        }

        public Student GetStudentById(int id)
        {
            var studentEntity = _userRegistrationRepository.GetStudentById(id);
            var student = _mapper.Map<Student>(studentEntity);
            return student;
        }

        public void UpdateStudent(Student student)
        {
            var existingStudentEntity = _userRegistrationRepository.GetStudentById(student.StudentId);

            if (existingStudentEntity == null)
            {
                throw new Exception("Student not found");
            }
            var updatedStudent = _mapper.Map<StudentEntity>(student);

            _userRegistrationRepository.UpdateStudent(updatedStudent);
        }
    }
}
