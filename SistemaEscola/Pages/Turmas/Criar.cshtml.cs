using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaEscola.Domain.Interfaces.Applications;
using SistemaEscola.Domain.Models.Turmas;

namespace SistemaEscola.Pages.Turmas
{
    public class CriarTurma : PageModel
    {
        private readonly ITurmaApplication _turmaApplication;

        public CriarTurma(ITurmaApplication turmaApplication)
        {
            _turmaApplication = turmaApplication;
        }

        public async Task<IActionResult> OnPostAsync(TurmaCreateModel turma)
        {
            var hasCreated = await _turmaApplication.Add(turma);

            if (!hasCreated)
                return RedirectToPage("/ErroRequisicao");

            return RedirectToPage("/Turmas/Listar");
        }
    }
}
