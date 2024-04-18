using Microsoft.AspNetCore.Mvc;
using SistemaEscola.Domain.Exceptions;
using SistemaEscola.Domain.Interfaces.Applications;
using SistemaEscola.Domain.Models;

namespace SistemaEscola.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TurmaController : ControllerBase
    {
        private readonly ITurmaApplication _turmaApplication;

        public TurmaController(ITurmaApplication turmaApplication)
        {
            _turmaApplication = turmaApplication;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _turmaApplication.GetAll());
            }
            catch (ErrorException ex)
            {
                return BadRequest(ErrorCodeModel.Create(ex.Code, ex.Message));
            }
        }
    }
}