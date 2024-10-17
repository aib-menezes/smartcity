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
        public async Task<IActionResult> GetRecursosPoliciais()
        {
            var recursos = await _recursoService.ListarRecursos();
            return Ok(recursos);
        }

        // GET: api/RecursosPoliciais/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecursosPoliciais(int id)
        {
            var recurso = await _recursoService.ObterRecursoPorId(id);

            if (recurso == null)
            {
                return NotFound(new { message = "Recurso policial não encontrado." });
            }

            return Ok(recurso);
        }

        // POST: api/RecursosPoliciais
        [HttpPost]
        public async Task<IActionResult> PostRecursosPoliciais([FromBody] RecursosPoliciais recurso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _recursoService.CriarRecurso(recurso);
            return CreatedAtAction(nameof(GetRecursosPoliciais), new { id = recurso.RecursoId }, recurso);
        }

        // PUT: api/RecursosPoliciais/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecursosPoliciais(int id, [FromBody] RecursosPoliciais recurso)
        {
            if (id != recurso.RecursoId)
            {
                return BadRequest(new { message = "O ID do recurso não corresponde ao fornecido." });
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _recursoService.AtualizarRecurso(recurso);
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Recurso policial não encontrado." });
            }

            return NoContent();
        }

        // DELETE: api/RecursosPoliciais/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecursosPoliciais(int id)
        {
            var recurso = await _recursoService.ObterRecursoPorId(id);
            if (recurso == null)
            {
                return NotFound(new { message = "Recurso policial não encontrado." });
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
