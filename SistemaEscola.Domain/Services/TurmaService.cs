using SistemaEscola.Domain.DTOs;
using SistemaEscola.Domain.Interfaces.Repositories;
using SistemaEscola.Domain.Interfaces.Services;

namespace SistemaEscola.Domain.Services
{
    public class TurmaService : ITurmaService
    {
        private readonly ITurmaRepository _turmaRepository;

        public TurmaService(ITurmaRepository turmaRepository)
        {
            _turmaRepository = turmaRepository;
        }

        public async Task<IEnumerable<TurmaDTO>> GetAll()
        {
            var result = await _turmaRepository.GetAll();

            return result;
        }

        public async Task<bool> Add(TurmaDTO turma)
        {
            // validar campos

            var result = await _turmaRepository.Add(turma);

            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var result = await _turmaRepository.Delete(id);

            return result;
        }
    }
}