using SistemaEscola.Domain.DTOs;
using SistemaEscola.Domain.Models.Alunos;

namespace SistemaEscola.Domain.Interfaces.Repositories
{
    public interface IAlunoRepository
    {
        Task<IEnumerable<AlunoDTO>> GetAll();
        Task<bool> Add(AlunoDTO aluno);
        Task<bool> Delete(int id);
    }
}