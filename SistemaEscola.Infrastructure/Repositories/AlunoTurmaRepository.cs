using Dapper;
using SistemaEscola.Domain.DTOs;
using SistemaEscola.Domain.Interfaces.Repositories;
using SistemaEscola.Infrastructure.Interfaces.Contexts;

namespace SistemaEscola.Infrastructure.Repositories
{
    public class AlunoTurmaRepository : IAlunoTurmaRepository
    {
        private readonly IDataContext _dataContext;

        public AlunoTurmaRepository(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<AlunoTurmaViewDTO>> GetAllByTurmaId(int turmaId)
        {
            string query = @"
                SELECT t.Turma, a.Id as IdAluno, a.Nome, a.Usuario
                FROM Aluno a
                INNER JOIN AlunoTurma at ON a.Id = at.AlunoId
                INNER JOIN Turma t ON t.Id = at.TurmaId
                WHERE t.Id = @TurmaId;";

            var parameters = new DynamicParameters();
            parameters.Add("@TurmaId", turmaId);

            return await _dataContext.GetAllAsync<AlunoTurmaViewDTO>(query, parameters, System.Data.CommandType.Text);
        }

        public async Task<bool> Add(AlunoTurmaDTO alunoTurma)
        {
            string query = @"INSERT INTO AlunoTurma (AlunoId, TurmaId) VALUES (@AlunoId, @TurmaId)";

            var parameters = new DynamicParameters();
            parameters.Add("@AlunoId", alunoTurma.AlunoId);
            parameters.Add("@TurmaId", alunoTurma.TurmaId);

            return await _dataContext.ExecuteAsync(query, parameters);
        }

        public async Task<bool> Delete(AlunoTurmaDTO alunoTurma)
        {
            string query = @"DELETE AlunoTurma WHERE AlunoId = @AlunoId and TurmaId = @TurmaId";

            var parameters = new DynamicParameters();
            parameters.Add("@AlunoId", alunoTurma.AlunoId);
            parameters.Add("@TurmaId", alunoTurma.TurmaId);

            return await _dataContext.ExecuteAsync(query, parameters);
        }
    }
}