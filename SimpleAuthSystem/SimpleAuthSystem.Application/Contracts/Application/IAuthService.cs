using SimpleAuthSystem.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAuthSystem.Application.Contracts.Application
{
    public interface IAuthService
    {
        Task<ServiceResponse<string>> RegisterAsync(RegisterRequest req);
        Task<ServiceResponse<TokenDto>> LoginAsync(LoginRequest req);
    }
}
