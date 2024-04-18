
using SistemaEscola.Domain.Models.Turmas;

namespace SistemaEscola.Domain.DTOs
{
    public class TurmaDTO
    {
        public int Id { get; set; }
        public int CursoId { get; set; }
        public string Turma { get; set; }
        public int Ano { get; set; }

        public static TurmaDTO Create(TurmaCreateModel turma) =>
            new()
            {
                CursoId = turma.CursoId,
                Turma = turma.Turma,
                Ano = turma.Ano
            };
    }
}