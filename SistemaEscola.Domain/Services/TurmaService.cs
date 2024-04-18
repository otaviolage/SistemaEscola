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
            var turmas = await _turmaRepository.GetAll();

            // Requisito: Sistema nao pode permitir Turmas com o mesmo nome (coluna turma no diagrama).
            if (turmas.Any(x => x.Turma == turma.Turma))
                return false;

            // Requisito: Sistema nao pode permitir criar Turmas com datas anteriores da atual.
            if (turma.Ano < DateTime.Now.Year)
                return false;

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