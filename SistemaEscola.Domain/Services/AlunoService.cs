using SistemaEscola.Domain.DTOs;
using SistemaEscola.Domain.Interfaces.Repositories;
using SistemaEscola.Domain.Interfaces.Services;
using SistemaEscola.Domain.Models.Alunos;

namespace SistemaEscola.Domain.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _orderRepository;

        public AlunoService(IAlunoRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<AlunoDTO>> GetAll()
        {
            var result = await _orderRepository.GetAll();

            return result;
        }

        public async Task<bool> Add(AlunoDTO aluno)
        {
            // validar campos

            var result = await _orderRepository.Add(aluno);

            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var result = await _orderRepository.Delete(id);

            return result;
        }
    }
}