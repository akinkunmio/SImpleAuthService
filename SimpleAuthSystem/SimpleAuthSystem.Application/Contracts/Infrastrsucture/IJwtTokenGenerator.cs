using SimpleAuthSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAuthSystem.Application.Contracts.Application
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
