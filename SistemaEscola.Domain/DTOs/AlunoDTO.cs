
using SistemaEscola.Domain.Models;
using SistemaEscola.Domain.Models.Alunos;

namespace SistemaEscola.Domain.DTOs
{
    public class AlunoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }

        public static AlunoDTO Create(AlunoCreateModel aluno) =>
            new()
            {
                Nome = aluno.Nome,
                Usuario = aluno.Usuario,
                Senha = aluno.Senha.ToSHA256Hash()
            };
    }
}