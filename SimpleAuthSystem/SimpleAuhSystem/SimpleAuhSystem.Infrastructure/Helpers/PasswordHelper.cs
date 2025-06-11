using Microsoft.AspNetCore.Identity;
using SimpleAuthSystem.Application.Contracts.Infrastrsucture;
using SimpleAuthSystem.Domain.Entities;
using PasswordVerificationResult = Microsoft.AspNetCore.Identity.PasswordVerificationResult;

namespace SimpleAuhSystem.Infrastructure.Services
{
    public class PasswordHelper(IPasswordHasher<User> _passwordHasher) : IPasswordHelper
    {
        public bool VerifyPassword(User user, string hashedPassword, string password)
        {
            var result = _passwordHasher.VerifyHashedPassword(user, hashedPassword, password);

            return result == PasswordVerificationResult.Success;
        }

        public string HashPassword(User user, string password)
        {
            return _passwordHasher.HashPassword(user, password);

        }
    }
}
