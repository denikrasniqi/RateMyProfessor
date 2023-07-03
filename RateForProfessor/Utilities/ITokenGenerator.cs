using RateForProfessor.Entities;

namespace RateForProfessor.Utilities
{
    public interface ITokenGenerator
    {
        string GenerateToken(StudentEntity student);
    }
}
