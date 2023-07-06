using RateForProfessor.Entities;

namespace RateForProfessor.Utilities.Interfaces
{
    public interface ITokenGenerator
    {
        string GenerateToken(StudentEntity student);
    }
}
