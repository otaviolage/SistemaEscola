using SistemaEscola.Domain.DTOs;

namespace SistemaEscola.Domain.Interfaces.Repositories
{
    public interface IAlunoRepository
    {
        Task<IEnumerable<AlunoDTO>> GetAll();
    }
}