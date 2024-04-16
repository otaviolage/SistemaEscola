using SistemaEscola.Domain.Enums;

namespace SistemaEscola.Domain.Models
{
    public class ErrorCodeModel
    {
        public ErrorCode Code { get; set; }
        public string Message { get; set; }

        public static ErrorCodeModel Create(ErrorCode code, string message) =>
            new()
            {
                Code = code,
                Message = message
            };
    }
}