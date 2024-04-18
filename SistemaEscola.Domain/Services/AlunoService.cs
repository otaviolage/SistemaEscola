using SistemaEscola.Domain.DTOs;
using SistemaEscola.Domain.Interfaces.Repositories;
using SistemaEscola.Domain.Interfaces.Services;

namespace SistemaEscola.Domain.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlunoService(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public async Task<IEnumerable<AlunoDTO>> GetAll()
        {
            var result = await _alunoRepository.GetAll();

            return result;
        }

        public async Task<bool> Add(AlunoDTO aluno)
        {
            // validar campos

            var result = await _alunoRepository.Add(aluno);

            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var result = await _alunoRepository.Delete(id);

            return result;
        }
    }
}