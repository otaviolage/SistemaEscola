using SistemaEscola.Domain.DTOs;

namespace SistemaEscola.Domain.Models.AlunoTurmas
{
    public class AlunoTurmaModel
    {
        public string Turma { get; set; }
        public int IdAluno { get; set; }
        public string Nome { get; set; }
        public string Usuario { get; set; }

        public static AlunoTurmaModel Create(AlunoTurmaViewDTO alunoTurma) =>
            new()
            {
                Turma = alunoTurma.Turma,
                IdAluno = alunoTurma.IdAluno,
                Nome = alunoTurma.Nome,
                Usuario = alunoTurma.Usuario
            };
    }
}