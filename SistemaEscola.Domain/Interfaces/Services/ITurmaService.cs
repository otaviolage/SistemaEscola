using SistemaEscola.Domain.DTOs;
using SistemaEscola.Domain.Models.Alunos;

namespace SistemaEscola.Domain.Interfaces.Services
{
    public interface ITurmaService
    {
        Task<IEnumerable<TurmaDTO>> GetAll();
        Task<bool> Add(TurmaDTO turma);
        Task<bool> Delete(int id);
    }
}