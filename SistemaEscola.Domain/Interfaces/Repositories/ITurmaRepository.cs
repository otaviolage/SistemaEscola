using SistemaEscola.Domain.DTOs;
using SistemaEscola.Domain.Models.Turmas;

namespace SistemaEscola.Domain.Interfaces.Repositories
{
    public interface ITurmaRepository
    {
        Task<IEnumerable<TurmaDTO>> GetAll();
        Task<IEnumerable<TurmaIdentificationDTO>> GetAllIdentifications();
        Task<bool> Add(TurmaDTO turma);
        Task<bool> Delete(int id);
    }
}