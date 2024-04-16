using SistemaEscola.Domain.Enums;
using SistemaEscola.Domain.Exceptions;
using System.IdentityModel.Tokens.Jwt;

namespace SistemaEscola.Middlewares
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _tokenAuth;


        public AuthenticationMiddleware(
            RequestDelegate next,
            IConfiguration configuration)
        {
            _next = next;
            _tokenAuth = configuration["TokenAuth:Secret"]!;

        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
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
            var authorization = httpContext.Request.Headers["Authorization"].ToString();

            if (string.IsNullOrWhiteSpace(authorization))
                throw new ErrorException(ErrorCode.Unauthorized, "Unauthorized");

            var token = authorization[authorization.IndexOf(" ")..].Trim();
            var handler = new JwtSecurityTokenHandler();

            try
            {
                var jsonToken = handler.ReadJwtToken(token);
                if (string.IsNullOrWhiteSpace(jsonToken.Issuer))
                    throw new ErrorException(ErrorCode.Unauthorized, "Unauthorized");

                var secretClaim = jsonToken.Claims.FirstOrDefault(c => c.Type == "secret")?.Value;

                if (secretClaim == null)
                    throw new ErrorException(ErrorCode.Unauthorized, "Unauthorized");

                if (secretClaim != _tokenAuth)
                    throw new ErrorException(ErrorCode.Unauthorized, "Invalid User");

            }
            catch (Exception)
            {
                throw new ErrorException(ErrorCode.Unauthorized, "Invalid token");
            }
        }
    }

    public static class AuthenticationExtensions
    {
        public static IApplicationBuilder UseAuthenticationMiddleware(this IApplicationBuilder builder) =>
            builder.UseMiddleware<AuthenticationMiddleware>();
    }
}