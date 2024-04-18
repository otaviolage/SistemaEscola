namespace SistemaEscola.Domain.Models.Turmas
{
    public class TurmaCreateModel
    {
        public int CursoId { get; set; }
        public string Turma { get; set; }
        public int Ano { get; set; }
    }
}