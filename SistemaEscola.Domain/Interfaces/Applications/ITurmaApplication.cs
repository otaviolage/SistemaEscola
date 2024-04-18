using SistemaEscola.Domain.Models.Turmas;

namespace SistemaEscola.Domain.Interfaces.Applications
{
    public interface ITurmaApplication
    {
        Task<IEnumerable<TurmaModel>> GetAll();
        Task<bool> Add(TurmaCreateModel turma);
        Task<bool> Delete(int id);
    }
}