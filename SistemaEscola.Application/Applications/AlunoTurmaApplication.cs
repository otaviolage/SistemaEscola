using SistemaEscola.Domain.DTOs;
using SistemaEscola.Domain.Interfaces.Applications;
using SistemaEscola.Domain.Interfaces.Services;
using SistemaEscola.Domain.Models.AlunoTurmas;

namespace SistemaEscola.Application.Applications
{
    public class AlunoTurmaApplication : IAlunoTurmaApplication
    {
        private readonly IAlunoTurmaService _alunoTurmaService;

        public AlunoTurmaApplication(
            IAlunoTurmaService alunoTurmaService)
        {
            _alunoTurmaService = alunoTurmaService;
        }

        public async Task<IEnumerable<AlunoTurmaModel>> GetAllByTurmaId(int turmaId)
        {
            var result = await _alunoTurmaService.GetAllByTurmaId(turmaId);

            return result.Select(AlunoTurmaModel.Create);
        }

        public async Task<bool> Add(AlunoTurmaCreateModel alunoTurma)
        {
            var alunoTurmaDto = AlunoTurmaDTO.Create(alunoTurma);

            var result = await _alunoTurmaService.Add(alunoTurmaDto);

            return result;
        }

        public async Task<bool> Delete(int idAluno, int idTurma)
        {
            var alunoTurma = AlunoTurmaDTO.Create(idAluno, idTurma);

            var result = await _alunoTurmaService.Delete(alunoTurma);

            return result;
        }
    }
}