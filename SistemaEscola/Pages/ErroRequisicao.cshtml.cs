using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace SistemaEscola.Pages
{
    public class ErroRequisicao : PageModel
    {
        private readonly ILogger<ErroRequisicao> _logger;

        public ErroRequisicao(ILogger<ErroRequisicao> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }

}
