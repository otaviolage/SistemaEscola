using SistemaEscola.Domain.DTOs;

namespace SistemaEscola.Domain.Models.Turmas
{
    public class TurmaModel
    {
        public int Id { get; set; }
        public int CursoId { get; set; }
        public string Turma { get; set; }
        public int Ano { get; set; }

        public static TurmaModel Create(TurmaDTO turma) =>
            new()
            {
                Id = turma.Id,
                CursoId = turma.CursoId,
                Turma = turma.Turma,
                Ano = turma.Ano
            };
    }
}