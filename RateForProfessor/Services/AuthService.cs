using RateForProfessor.Entities;
using RateForProfessor.Repositories;
using RateForProfessor.Repositories.Interfaces;
using RateForProfessor.Services.Interfaces;
using RateForProfessor.Utilities;

namespace RateForProfessor.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly ITokenGenerator _tokenGenerator;

        public AuthService(IAuthRepository authRepository, ITokenGenerator tokenGenerator)
        {
            _authRepository = authRepository;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<string> AuthenticateUser(string email, string password)
        {
            // Validate user credentials
            var user = await _authRepository.AuthenticateUser(email, password);
            if (user == null)
            {
                return null;
            }

            // Additional validation and business logic

            // Generate and return the authentication token
            var token = _tokenGenerator.GenerateToken(user);
            return token;
        }
    }
}
