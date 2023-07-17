using RateForProfessor.Entities;
using RateForProfessor.Enums;

namespace RateForProfessor.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public List<UserEntity> GetAllUsers();

        public UserEntity GetUserById(int id);

        public UserEntity GetUserByEmail(string email);

        public UserEntity GetUserByName(string name);

        public UserEntity GetUserByRole(Role role);

        public UserEntity CreateUser(UserEntity user);

        public void UpdateUser(UserEntity user);

        public void DeleteUser(int id);
    }
}
