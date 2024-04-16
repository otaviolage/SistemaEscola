using SistemaEscola.Domain.DTOs;

namespace SistemaEscola.Domain.Models.Alunos
{
    public class AlunoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Usuario { get; set; }
        public char Senha { get; set; }

        public static AlunoModel Create(AlunoDTO aluno) =>
            new()
            {
                Id = aluno.Id,
                Nome = aluno.Nome,
                Usuario = aluno.Usuario
            };
    }
}