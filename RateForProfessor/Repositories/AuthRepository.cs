using System.Linq;
using Microsoft.EntityFrameworkCore;
using RateForProfessor.Context;
using RateForProfessor.Entities;
using RateForProfessor.Repositories.Interfaces;
using System.Threading.Tasks;

namespace RateForProfessor.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly AppDbContext _dbContext;

        public AuthRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<StudentEntity> AuthenticateUser(string email, string password)
        {
            var student = await _dbContext.Students.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
            return student;
        }
    }
}