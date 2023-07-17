using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RateForProfessor.Entities;
using RateForProfessor.Enums;
using RateForProfessor.Models;
using RateForProfessor.Repositories;
using RateForProfessor.Repositories.Interfaces;
using RateForProfessor.Services.Interfaces;

namespace RateForProfessor.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public User CreateUser(User user)
        {
            try
            {
                var userEntity = _mapper.Map<UserEntity>(user);
                userEntity.Role = Role.Admin;

                var result = _userRepository.CreateUser(userEntity);

                var userCreated = _mapper.Map<User>(user);
                return userCreated;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteUser(int id)
        {
            _userRepository.DeleteUser(id);
        }

        public List<User> GetAllUsers()
        {
            var userEntities = _userRepository.GetAllUsers();
            var users = _mapper.Map<List<User>>(userEntities);
            return users;
        }

        public User GetUserByEmail(string email)
        {
            var userEntity = _userRepository.GetUserByEmail(email);
            var user= _mapper.Map<User>(userEntity);
            return user;
        }

        public User GetUserById(int id)
        {
            var userEntity = _userRepository.GetUserById(id);
            var user = _mapper.Map<User>(userEntity);
            return user;
        }

        public User GetUserByName(string name)
        {
            var userEntity = _userRepository.GetUserByName(name);
            var user = _mapper.Map<User>(userEntity);
            return user;
        }

        //public User GetUserByRole(Role role)
        //{
        //    var user = _userRepository.GetUserByRole(u => u.Role == role);
        //    return user;
        //}

        public void UpdateUser(User user)
        {
            var existingUserEntity = _userRepository.GetUserById(user.UserId);

            if (existingUserEntity == null)
            {
                throw new Exception("User not found");
            }
            var updatedUser = _mapper.Map<UserEntity>(user);

            _userRepository.UpdateUser(updatedUser);
        }
    }
}
