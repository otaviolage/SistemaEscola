using Dapper;
using SistemaEscola.Domain.DTOs;
using SistemaEscola.Domain.Interfaces.Repositories;
using SistemaEscola.Infrastructure.Interfaces.Contexts;

namespace SistemaEscola.Infrastructure.Repositories
{
    public class TurmaRepository : ITurmaRepository
    {
        private readonly IDataContext _dataContext;

        public TurmaRepository(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<TurmaDTO>> GetAll()
        {
            string query = @$"SELECT Id, CursoId, Turma, Ano FROM Turma";

            return await _dataContext.GetAllAsync<TurmaDTO>(query, default, System.Data.CommandType.Text);
        }

        public async Task<IEnumerable<TurmaIdentificationDTO>> GetAllIdentifications()
        {
            string query = @$"SELECT Turma FROM Turma";

            return await _dataContext.GetAllAsync<TurmaIdentificationDTO>(query, default, System.Data.CommandType.Text);
        }

        public async Task<bool> Add(TurmaDTO turma)
        {
            string query = @"INSERT INTO Turma (CursoId, Turma, Ano) VALUES (@CursoId, @Turma, @Ano)";

            var parameters = new DynamicParameters();
            parameters.Add("@CursoId", turma.CursoId);
            parameters.Add("@Turma", turma.Turma);
            parameters.Add("@Ano", turma.Ano);

            return await _dataContext.ExecuteAsync(query, parameters);
        }

        public async Task<bool> Delete(int id)
        {
            string query = @"DELETE Turma WHERE Id = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);

            return await _dataContext.ExecuteAsync(query, parameters);
        }
    }
}