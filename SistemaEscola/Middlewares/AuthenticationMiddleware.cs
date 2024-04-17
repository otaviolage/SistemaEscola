using Microsoft.IdentityModel.Tokens;
using SistemaEscola.Domain.Enums;
using SistemaEscola.Domain.Exceptions;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SistemaEscola.Middlewares
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _authUser;
        private readonly string _authSecret;
        private readonly string _authIss;
        private readonly string _authAud;

        public AuthenticationMiddleware(
            RequestDelegate next,
            IConfiguration configuration)
        {
            _next = next;
            _authUser = configuration["Auth:User"]!;
            _authSecret = configuration["Auth:Secret"]!;
            _authIss = configuration["Auth:Iss"]!;
            _authAud = configuration["Auth:Aud"]!;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                if (((string)httpContext.Request.Path).StartsWith("/api"))
                    ValidateToken(httpContext);
            }
            catch (ErrorException ex)
            {
                httpContext.Response.StatusCode = (int)ex.Code;
                httpContext.Response.ContentType = "application/json";
                await httpContext.Response.WriteAsync(ex.Message);
                return;
            }

            await _next(httpContext);
        }

        public void ValidateToken(HttpContext httpContext)
        {
            var authorization = httpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            if (!string.IsNullOrEmpty(authorization))
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(_authSecret);

                try
                {
                    tokenHandler.ValidateToken(authorization, new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = true,
                        ValidIssuer = _authIss,
                        ValidateAudience = true,
                        ValidAudience = _authAud,
                        ValidateLifetime = true
                    }, out SecurityToken validatedToken);
                }
                catch (SecurityTokenException)
                {
                    throw new ErrorException(ErrorCode.Unauthorized, "Unauthorized");
                }
            }
            else
            {
                throw new ErrorException(ErrorCode.Unauthorized, "Unauthorized");

            }
        }
    }

    public static class AuthenticationExtensions
    {
        public static IApplicationBuilder UseAuthenticationMiddleware(this IApplicationBuilder builder) =>
            builder.UseMiddleware<AuthenticationMiddleware>();
    }
}