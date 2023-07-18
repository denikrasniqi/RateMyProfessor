using RateForProfessor.Context;
using RateForProfessor.Entities;
using RateForProfessor.Enums;
using RateForProfessor.Repositories.Interfaces;

namespace RateForProfessor.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;

        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public UserEntity CreateUser(UserEntity user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return user;
        }

        public void DeleteUser(int id)
        {
            var user = _dbContext.Users.Find(id);
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
        }

        public List<UserEntity> GetAllUsers() 
        {
            return _dbContext.Users.ToList();
        }

        public UserEntity GetUserById(int id)
        {
            return _dbContext.Users.Find(id);
        }

        public UserEntity GetUserByEmail(string email)
        {
            var user= _dbContext.Users.FirstOrDefault(u => u.Email == email);
            return user;
        }

        public UserEntity GetUserByName(string name)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Name == name);
            return user;
        }

        public UserEntity GetUserByRole(Role role)
        {
            //var user = _dbContext.Users.FirstOrDefault(u => u.Role.Equals(role));
            //return user;

            var user = _dbContext.Users.FirstOrDefault(u => u.Role == role);
            return user;
        }

        public void UpdateUser(UserEntity user)
        {
            var olduser = _dbContext.Users.Find(user.UserId);
            _dbContext.Entry(olduser).CurrentValues.SetValues(user);
            _dbContext.SaveChanges();
        }

    }
}
