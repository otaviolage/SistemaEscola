using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaEscola.Domain.Interfaces.Applications;
using SistemaEscola.Domain.Models.Turmas;

namespace SistemaEscola.Pages.Turmas
{
    public class Turma : PageModel
    {
        private readonly ITurmaApplication _turmaApplication;
        public IEnumerable<TurmaModel> Turmas { get; private set; }

        public Turma(ITurmaApplication turmaApplication)
        {
            _turmaApplication = turmaApplication;
        }

        public async Task OnGet()
        {
            Turmas = await _turmaApplication.GetAll();
        }

        public async Task<IActionResult> OnPostInativarAsync(int id)
        {
            var hasCreated = await _turmaApplication.Delete(id);

            if (!hasCreated)
                return RedirectToPage("/ErroRequisicao");

            return RedirectToPage();
        }
    }
}
