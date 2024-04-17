using SistemaEscola.Domain.DTOs;
using SistemaEscola.Domain.Models.Alunos;

namespace SistemaEscola.Domain.Interfaces.Services
{
    public interface IAlunoService
    {
        Task<IEnumerable<AlunoDTO>> GetAll();
        Task<bool> Add(AlunoDTO aluno);
        Task<bool> Delete(int id);
    }
}