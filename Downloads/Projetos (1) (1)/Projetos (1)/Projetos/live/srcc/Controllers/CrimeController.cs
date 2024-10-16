using Microsoft.AspNetCore.Mvc;
using SmartCitySecurity.Models;
using SmartCitySecurity.Services;
using SmartCitySecurity.srcc.Services;


namespace SmartCitySecurity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrimesController : ControllerBase
    {
        private readonly ICrimeService _crimeService;

        public CrimesController(ICrimeService crimeService)
        {
            _crimeService = crimeService;
        }

        // GET: api/crimes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ModeloCrime>>> GetCrimes()
        {
            var crimes = await _crimeService.ListarCrimes();
            return Ok(crimes);
        }

        // GET: api/crimes/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ModeloCrime>> GetCrime(int id)
        {
            var crime = await _crimeService.ObterCrimePorId(id);
            if (crime == null)
            {
                return NotFound();
            }
            return Ok(crime);
        }

        // POST: api/crimes
        [HttpPost]
        public async Task<ActionResult<ModeloCrime>> PostCrime(ModeloCrime crime)
        {
            await _crimeService.CriarCrime(crime);
            return CreatedAtAction(nameof(GetCrime), new { id = crime.CrimeId }, crime);
        }

        // PUT: api/crimes/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCrime(int id, ModeloCrime crime)
        {
            if (id != crime.CrimeId)
            {
                return BadRequest();
            }

            await _crimeService.AtualizarCrime(crime);
            return NoContent();
        }

        // DELETE: api/crimes/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCrime(int id)
        {
            var crime = await _crimeService.ObterCrimePorId(id);
            if (crime == null)
            {
                return NotFound();
            }

            await _crimeService.DeletarCrime(id);
            return NoContent();
        }
    }
}
