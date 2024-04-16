using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaEscola.Domain.Interfaces.Applications;

namespace SistemaEscola.Pages
{
    public class Aluno : PageModel
    {
        private readonly IAlunoApplication _alunoApplication;
        public IEnumerable<Domain.Models.Alunos.AlunoModel> Alunos { get; private set; }

        public Aluno(IAlunoApplication alunoApplication)
        {
            _alunoApplication = alunoApplication;
        }

        public async Task OnGet()
        {
            Alunos = await _alunoApplication.GetAll();
        }
    }
}
