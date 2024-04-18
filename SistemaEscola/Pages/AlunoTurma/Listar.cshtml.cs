using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaEscola.Domain.DTOs;
using SistemaEscola.Domain.Interfaces.Applications;
using SistemaEscola.Domain.Models.AlunoTurmas;
using SistemaEscola.Pages.Turmas;

namespace SistemaEscola.Pages.AlunoTurma
{
    public class AlunoTurma : PageModel
    {
        private readonly IAlunoTurmaApplication _turmaApplication;
        public IEnumerable<AlunoTurmaModel> AlunoTurmas { get; private set; }

        public AlunoTurma(IAlunoTurmaApplication turmaApplication)
        {
            _turmaApplication = turmaApplication;
        }

        public async Task OnGet(int turmaId)
        {
            AlunoTurmas = await _turmaApplication.GetAllByTurmaId(turmaId);
        }

        public async Task<IActionResult> OnPostInativarAsync(int idAluno, int idTurma)
        {
            var hasCreated = await _turmaApplication.Delete(idAluno, idTurma);

            if (!hasCreated)
                return RedirectToPage("/ErroRequisicao");

            return RedirectToPage();
        }
    }
}
