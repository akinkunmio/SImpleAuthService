using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAuthSystem.Application.DTOs
{
    public record LoginRequest([EmailAddress] string Email,[Required] string Password);
}
