using SistemaEscola.Domain.DTOs;
using SistemaEscola.Domain.Interfaces.Repositories;
using SistemaEscola.Domain.Interfaces.Services;

namespace SistemaEscola.Domain.Services
{
    public class AlunoTurmaService : IAlunoTurmaService
    {
        private readonly IAlunoTurmaRepository _alunoTurmaRepository;

        public AlunoTurmaService(IAlunoTurmaRepository alunoTurmaRepository)
        {
            _alunoTurmaRepository = alunoTurmaRepository;
        }

        public async Task<IEnumerable<AlunoTurmaViewDTO>> GetAllByTurmaId(int turmaId)
        {
            var result = await _alunoTurmaRepository.GetAllByTurmaId(turmaId);

            return result;
        }

        public async Task<bool> Add(AlunoTurmaDTO alunoTurma)
        {
            var alunos = await GetAllByTurmaId(alunoTurma.TurmaId);

            //Requisito: Sistema nao pode permitir o mesmo Aluno relacionado na mesma Turma duas vezes.
            if (alunos.Any(x => x.IdAluno == alunoTurma.AlunoId))
                return false;

            var result = await _alunoTurmaRepository.Add(alunoTurma);

            return result;
        }

        public async Task<bool> Delete(AlunoTurmaDTO alunoTurma)
        {
            var result = await _alunoTurmaRepository.Delete(alunoTurma);

            return result;
        }
    }
}