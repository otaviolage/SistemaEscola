using SistemaEscola.Domain.DTOs;

namespace SistemaEscola.Domain.Models.Alunos
{
    public class AlunoCreateModel
    {
        public string Nome { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
    }
}