namespace RateForProfessor.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> AuthenticateUser(string email, string password);
    }
}