using Microsoft.AspNetCore.Mvc;
using SmartCitySecurity.Models;
using SmartCitySecurity.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartCitySecurity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecursosPoliciaisController : ControllerBase
    {
        private readonly IRecursoService _recursoService;

        public RecursosPoliciaisController(IRecursoService recursoService)
        {
            _recursoService = recursoService;
        }

        // GET: api/RecursosPoliciais
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecursosPoliciais>>> GetRecursosPoliciais()
        {
            var recursos = await _recursoService.ListarRecursos();
            return Ok(recursos);
        }

        // GET: api/RecursosPoliciais/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RecursosPoliciais>> GetRecursosPoliciais(int id)
        {
            var recurso = await _recursoService.ObterRecursoPorId(id);

            if (recurso == null)
            {
                return NotFound();
            }

            return Ok(recurso);
        }

        // POST: api/RecursosPoliciais
        [HttpPost]
        public async Task<ActionResult<RecursosPoliciais>> PostRecursosPoliciais(RecursosPoliciais recurso)
        {
            await _recursoService.CriarRecurso(recurso);
            return CreatedAtAction(nameof(GetRecursosPoliciais), new { id = recurso.RecursoId }, recurso);
        }

        // PUT: api/RecursosPoliciais/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecursosPoliciais(int id, RecursosPoliciais recurso)
        {
            if (id != recurso.RecursoId)
            {
                return BadRequest();
            }

            await _recursoService.AtualizarRecurso(recurso);
            return NoContent();
        }

        // DELETE: api/RecursosPoliciais/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecursosPoliciais(int id)
        {
            var recurso = await _recursoService.ObterRecursoPorId(id);
            if (recurso == null)
            {
                return NotFound();
            }

            await _recursoService.DeletarRecurso(id);
            return NoContent();
        }

        // PUT: api/RecursosPoliciais/atualizar-status
        [HttpPut("atualizar-status")]
        public async Task<IActionResult> AtualizarStatusDisponibilidade()
        {
            await _recursoService.AtualizarStatusDisponibilidade();
            return NoContent();
        }
    }
}
