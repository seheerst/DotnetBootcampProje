using DotnetBootcampProje.Core.Dtos;
using DotnetBootcampProje.Core.Dtos.Authentication;
using DotnetBootcampProje.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetBootcampProje.Core.Services
{
    public interface ITeacherService: IGenericService<Teacher>
    {
        string GeneratePasswordHash(string email, string password);
        TeacherDto FindUser(string email, string password);
        AuthResponseDto Login(AuthRequestDto request);
        Teacher SignUp(AuthRequestDto authDto);
    }
}
