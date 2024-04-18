using SistemaEscola.Domain.DTOs;

namespace SistemaEscola.Domain.Interfaces.Services
{
    public interface IAlunoTurmaService
    {
        Task<IEnumerable<AlunoTurmaViewDTO>> GetAllByTurmaId(int turmaId);
        Task<bool> Add(AlunoTurmaDTO aluno);
        Task<bool> Delete(AlunoTurmaDTO alunoTurma);
    }
}