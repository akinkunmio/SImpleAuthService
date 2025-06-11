using Microsoft.AspNet.Identity;
using SimpleAuthSystem.Application.Contracts.Application;
using SimpleAuthSystem.Application.Contracts.Infrastrsucture;
using SimpleAuthSystem.Application.DTOs;
using SimpleAuthSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAuthSystem.Application.Services
{
    public class AuthService(IUserRepository _repo, IJwtTokenGenerator _jwt, IPasswordHelper _helper) : IAuthService
    {
        public async Task<ServiceResponse<string>> RegisterAsync(RegisterRequest req)
        {
            if (string.IsNullOrWhiteSpace(req.Email))
                return new ServiceResponse<string>("Invalid email address");
            
            if (string.IsNullOrWhiteSpace(req.Password) || req.Password.Length < 6)
                return new ServiceResponse<string>("Password is less than 6 characters. Required password length is 8");
            
            if (await _repo.GetByEmailAsync(req.Email) is not null)
                return new ServiceResponse<string>("User already exists", false, (int)HttpStatusCode.Conflict);

            var user = new User { Id = Guid.NewGuid(), Email = req.Email };

            user.PasswordHash = _helper.HashPassword(user, req.Password);
            await _repo.AddAsync(user);

            return new ServiceResponse<string>("Registration successful", true, (int)HttpStatusCode.Created);
        }

        public async Task<ServiceResponse<TokenDto>> LoginAsync(LoginRequest req)
        {
            if (string.IsNullOrWhiteSpace(req.Email) )
                return new ServiceResponse<TokenDto>("Invalid email address", false, default);

            var user = await _repo.GetByEmailAsync(req.Email);
            if (user == null)
               return new ServiceResponse<TokenDto>("Invalid credentials", false, (int)HttpStatusCode.NotFound, default);
            
            var result = _helper.VerifyPassword(user, user.PasswordHash, req.Password);
            if (!result)
                return new ServiceResponse<TokenDto>("Invalid credentials", false, default);

            var tokenDto = new TokenDto(_jwt.GenerateToken(user), DateTime.Now.AddHours(1)); 
           
            return new ServiceResponse<TokenDto>("Login successful", true, (int)HttpStatusCode.OK, tokenDto);
        }
    }
}
