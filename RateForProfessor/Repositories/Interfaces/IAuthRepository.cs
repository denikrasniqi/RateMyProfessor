using RateForProfessor.Entities;
using RateForProfessor.Models;

namespace RateForProfessor.Repositories.Interfaces
{
    public interface IAuthRepository
    {
        Task<UserEntity> AuthenticateUser(string email, string password);
    }
}