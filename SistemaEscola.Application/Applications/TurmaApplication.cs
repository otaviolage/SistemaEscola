using SistemaEscola.Domain.DTOs;
using SistemaEscola.Domain.Interfaces.Applications;
using SistemaEscola.Domain.Interfaces.Services;
using SistemaEscola.Domain.Models.Turmas;

namespace SistemaEscola.Application.Applications
{
    public class TurmaApplication : ITurmaApplication
    {
        private readonly ITurmaService _turmaService;

        public TurmaApplication(
            ITurmaService turmaService)
        {
            _turmaService = turmaService;
        }

        public async Task<IEnumerable<TurmaModel>> GetAll()
        {
            var result = await _turmaService.GetAll();

            return result.Select(TurmaModel.Create);
        }

        public async Task<bool> Add(TurmaCreateModel turma)
        {
            var turmaDto = TurmaDTO.Create(turma);

            var result = await _turmaService.Add(turmaDto);

            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var result = await _turmaService.Delete(id);

            return result;
        }
    }
}