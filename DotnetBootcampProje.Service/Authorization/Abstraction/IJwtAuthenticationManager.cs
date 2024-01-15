using DotnetBootcampProje.Core.Dtos.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetBootcampProje.Service.Authorization.Abstraction
{
    public interface IJwtAuthenticationManager
    {
        AuthResponseDto Authenticate(string email, string password);
        int? ValidateJwtToken(string token);
    }
}
