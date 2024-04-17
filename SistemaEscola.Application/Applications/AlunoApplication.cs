using SistemaEscola.Domain.DTOs;
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

        public async Task<bool> Add(AlunoCreateModel aluno)
        {
            var alunoDto = AlunoDTO.Create(aluno);

            var result = await _alunoService.Add(alunoDto);

            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var result = await _alunoService.Delete(id);

            return result;
        }
    }
}