using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaEscola.Domain.Interfaces.Applications;
using SistemaEscola.Domain.Models.AlunoTurmas;
using SistemaEscola.Domain.Models.Alunos;
using SistemaEscola.Domain.Models.Turmas;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaEscola.Pages.AlunoTurma
{
    public class CriarAlunoTurmaModel : PageModel
    {
        private readonly IAlunoTurmaApplication _alunoTurmaApplication;
        private readonly IAlunoApplication _alunoApplication;
        private readonly ITurmaApplication _turmaApplication;

        public CriarAlunoTurmaModel(
            IAlunoTurmaApplication alunoTurmaApplication, 
            IAlunoApplication alunoApplication, 
            ITurmaApplication turmaApplication)
        {
            _alunoTurmaApplication = alunoTurmaApplication;
            _alunoApplication = alunoApplication;
            _turmaApplication = turmaApplication;
        }

        public IEnumerable<AlunoModel> Alunos { get; set; }
        public IEnumerable<TurmaModel> Turmas { get; set; }

        [BindProperty]
        public AlunoTurmaCreateModel AlunoTurma { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                Alunos = await _alunoApplication.GetAll();
                Turmas = await _turmaApplication.GetAll();
                return Page();
            }
            catch (Exception)
            {
                return RedirectToPage("/ErroRequisicao");
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                var hasCreated = await _alunoTurmaApplication.Add(AlunoTurma);

                if (!hasCreated)
                    return RedirectToPage("/ErroRequisicao");

                return RedirectToPage("/Turmas/Listar");
            }
            catch (Exception)
            {
                return RedirectToPage("/ErroRequisicao");
            }
        }
    }
}
