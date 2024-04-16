using SistemaEscola.Domain.Interfaces.Applications;
using SistemaEscola.Domain.Interfaces.Services;
using SistemaEscola.Domain.Models.Alunos;

namespace SistemaEscola.Application.Applications
{
    public class AlunoApplication : IAlunoApplication
    {
        private readonly IAlunoService _alunoService;

        public AlunoApplication(
            IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        public async Task<IEnumerable<AlunoModel>> GetAll()
        {
            var result = await _alunoService.GetAll();

            return result.Select(AlunoModel.Create);
        }
    }
}