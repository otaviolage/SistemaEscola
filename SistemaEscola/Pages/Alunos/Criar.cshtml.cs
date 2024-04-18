using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaEscola.Domain.Interfaces.Applications;
using SistemaEscola.Domain.Models.Alunos;

namespace SistemaEscola.Pages.Alunos
{
    public class CriarAluno : PageModel
    {
        private readonly IAlunoApplication _alunoApplication;

        public CriarAluno(IAlunoApplication alunoApplication)
        {
            _alunoApplication = alunoApplication;
        }

        public async Task<IActionResult> OnPostAsync(AlunoCreateModel aluno)
        {
            var hasCreated = await _alunoApplication.Add(aluno);

            if (!hasCreated)
                return RedirectToPage("/ErroRequisicao");

            return RedirectToPage("/Alunos/Listar");
        }
    }
}
