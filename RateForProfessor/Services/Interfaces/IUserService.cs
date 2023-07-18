using RateForProfessor.Entities;
using RateForProfessor.Enums;
using RateForProfessor.Models;

namespace RateForProfessor.Services.Interfaces
{
    public interface IUserService
    {
        public List<User> GetAllUsers();

        public User GetUserById(int id);

        public User GetUserByEmail(string email);

        public User GetUserByName(string name);

       // public User GetUserByRole(Role role);

        public User CreateUser(User user);

        public void UpdateUser(User user);

        public void DeleteUser(int id);
    }
}
