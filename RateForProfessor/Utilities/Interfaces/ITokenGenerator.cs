using RateForProfessor.Entities;

namespace RateForProfessor.Utilities.Interfaces
{
    public interface ITokenGenerator
    {
        string GenerateToken(UserEntity user);
    }
}
