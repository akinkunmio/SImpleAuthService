using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using SimpleAuthSystem.Application.Contracts.Infrastrsucture;
using SimpleAuthSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordVerificationResult = Microsoft.AspNetCore.Identity.PasswordVerificationResult;

namespace SimpleAuhSystem.Infrastructure.Services
{
    public class PasswordHelper(IPasswordHasher<User> _passwordHasher) : IPasswordHelper
    {
        public bool VerifyPassword(User user, string hashedPassword, string password)
        {
            var result = _passwordHasher.VerifyHashedPassword(user, hashedPassword, password);
            // if required, you can handle if result is SuccessRehashNeeded
            return result == PasswordVerificationResult.Success;
        }

        public string HashPassword(User user, string password)
        {
            return _passwordHasher.HashPassword(user, password);

        }
    }
}
