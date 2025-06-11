using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAuthSystem.Application.DTOs
{
    public record TokenDto(string AccessToken, DateTime ExpiresAt)
    {
        public TokenDto() : this(string.Empty, DateTime.MinValue) { } // Default constructor

    }
}