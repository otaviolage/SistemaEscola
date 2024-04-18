using SistemaEscola.Domain.DTOs;
using SistemaEscola.Domain.Models.AlunoTurmas;

namespace SistemaEscola.Domain.Interfaces.Repositories
{
    public interface IAlunoTurmaRepository
    {
        Task<IEnumerable<AlunoTurmaViewDTO>> GetAllByTurmaId(int turmaId);
        Task<bool> Add(AlunoTurmaDTO alunoTurma);
        Task<bool> Delete(AlunoTurmaDTO alunoTurma);
    }
}