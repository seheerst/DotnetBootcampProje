using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetBootcampProje.Core.Dtos.Authentication
{
    public class AuthResponseDto
    {
        public string Token { get; set; }
        public TeacherDto Teacher { get; set; }
    }
}
