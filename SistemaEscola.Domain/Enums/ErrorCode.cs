using System.Net;

namespace SistemaEscola.Domain.Enums
{
    public enum ErrorCode
    {
        NotFound = HttpStatusCode.NotFound,
        BadRequest = HttpStatusCode.BadRequest,
        Unauthorized = HttpStatusCode.Unauthorized
    }
}