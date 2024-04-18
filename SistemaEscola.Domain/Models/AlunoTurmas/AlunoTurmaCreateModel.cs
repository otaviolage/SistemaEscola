using SistemaEscola.Domain.DTOs;

namespace SistemaEscola.Domain.Models.AlunoTurmas
{
    public class AlunoTurmaCreateModel
    {
        public int AlunoId { get; set; }
        public int TurmaId { get; set; }

        public static AlunoTurmaCreateModel Create(AlunoTurmaDTO alunoTurma) =>
            new()
            {
                AlunoId = alunoTurma.AlunoId,
                TurmaId = alunoTurma.TurmaId
            };
    }
}