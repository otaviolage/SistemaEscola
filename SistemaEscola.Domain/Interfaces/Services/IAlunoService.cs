using SistemaEscola.Domain.DTOs;

namespace SistemaEscola.Domain.Interfaces.Services
{
    public interface IAlunoService
    {
        Task<IEnumerable<AlunoDTO>> GetAll();
    }
}