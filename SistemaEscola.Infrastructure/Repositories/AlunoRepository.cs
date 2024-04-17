using SistemaEscola.Domain.DTOs;
using SistemaEscola.Domain.Interfaces.Repositories;
using SistemaEscola.Infrastructure.Interfaces.Contexts;

namespace SistemaEscola.Infrastructure.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly IDataContext _dataContext;

        public AlunoRepository(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<AlunoDTO>> GetAll()
        {
            string query = @$"SELECT Id, Nome, Usuario FROM Aluno";

            return await _dataContext.GetAllAsync<AlunoDTO>(query, default, System.Data.CommandType.Text);
        }
    }
}