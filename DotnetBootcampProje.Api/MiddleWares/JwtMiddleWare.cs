using DotnetBootcampProje.Core.Services;
using DotnetBootcampProje.Service.Authorization.Abstraction;

namespace DotnetBootcampProje.Api.MiddleWares
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, ITeacherService teacherService, IJwtAuthenticationManager iJwtAuthenticationManager)
        {
            var authorizationHeader = context.Request.Headers["Authorization"].FirstOrDefault();
            string token = null;

            if (!string.IsNullOrEmpty(authorizationHeader))
            {
                var parts = authorizationHeader.Split(" ");
                if (parts.Length > 1)
                {
                    token = parts[parts.Length - 1];
                }
            }

            var teacherId = iJwtAuthenticationManager.ValidateJwtToken(token);
            if (teacherId != null)
            {
                context.Items["User"] = teacherService.GetById(teacherId.Value).Result;
            }

            await _next(context);
        }
    }
}
