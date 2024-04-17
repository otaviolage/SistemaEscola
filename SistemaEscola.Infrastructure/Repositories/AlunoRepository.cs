using Dapper;
using SistemaEscola.Domain.DTOs;
using SistemaEscola.Domain.Interfaces.Repositories;
using SistemaEscola.Domain.Models.Alunos;
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

        public async Task<bool> Add(AlunoDTO aluno)
        {
            string query = @"INSERT INTO Aluno (Nome, Usuario, SenhaHash) VALUES (@Nome, @Usuario, @SenhaHash)";

            var parameters = new DynamicParameters();
            parameters.Add("@Nome", aluno.Nome);
            parameters.Add("@Usuario", aluno.Usuario);
            parameters.Add("@SenhaHash", aluno.Senha);

            return await _dataContext.ExecuteAsync(query, parameters);
        }

        public async Task<bool> Delete(int id)
        {
            string query = @"DELETE Aluno WHERE Id = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);

            return await _dataContext.ExecuteAsync(query, parameters);
        }
    }
}