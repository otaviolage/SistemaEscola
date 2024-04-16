using SistemaEscola.Domain.DTOs;
using SistemaEscola.Domain.Interfaces.Repositories;
using SistemaEscola.Domain.Interfaces.Services;

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
    }
}