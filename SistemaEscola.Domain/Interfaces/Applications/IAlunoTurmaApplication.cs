using SistemaEscola.Domain.DTOs;
using SistemaEscola.Domain.Models.Alunos;
using SistemaEscola.Domain.Models.AlunoTurmas;

namespace SistemaEscola.Domain.Interfaces.Applications
{
    public interface IAlunoTurmaApplication
    {
        Task<IEnumerable<AlunoTurmaModel>> GetAllByTurmaId(int turmaId);
        Task<bool> Add(AlunoTurmaCreateModel alunoTurma);
        Task<bool> Delete(int idAluno, int idTurma);
    }
}