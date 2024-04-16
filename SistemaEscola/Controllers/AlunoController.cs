using Microsoft.AspNetCore.Mvc;
using SistemaEscola.Domain.Exceptions;
using SistemaEscola.Domain.Interfaces.Applications;
using SistemaEscola.Domain.Models;

namespace SistemaEscola.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoApplication _alunoApplication;

        public AlunoController(IAlunoApplication alunoApplication)
        {
            _alunoApplication = alunoApplication;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _alunoApplication.GetAll());
            }
            catch (ErrorException ex)
            {
                return BadRequest(ErrorCodeModel.Create(ex.Code, ex.Message));
            }
        }
    }
}