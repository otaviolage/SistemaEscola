using SistemaEscola.Domain.Models.Alunos;

namespace SistemaEscola.Domain.Interfaces.Applications
{
    public interface IAlunoApplication
    {
        Task<IEnumerable<AlunoModel>> GetAll();
    }
}