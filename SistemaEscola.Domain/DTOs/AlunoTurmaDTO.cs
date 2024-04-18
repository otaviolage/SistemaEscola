using SistemaEscola.Domain.Models.Alunos;
using SistemaEscola.Domain.Models.AlunoTurmas;

namespace SistemaEscola.Domain.DTOs
{
    public class AlunoTurmaDTO
    {
        public int AlunoId { get; set; }
        public int TurmaId { get; set; }

        public static AlunoTurmaDTO Create(AlunoTurmaCreateModel alunoTurma) =>
            new()
            {
                AlunoId = alunoTurma.AlunoId,
                TurmaId = alunoTurma.TurmaId
            };

        public static AlunoTurmaDTO Create(int idAluno, int idTurma) =>
            new()
            {
                AlunoId = idAluno,
                TurmaId = idTurma
            };
    }
}