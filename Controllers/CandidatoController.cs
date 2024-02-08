using atsback.Entities;
using atsback.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace atsback.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CandidatoController : ControllerBase
    {
        private readonly ICandidatoRepository _repository;
        public CandidatoController(ICandidatoRepository repository) {
            _repository = repository ??
             throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Candidato>>> GetCandidatos()
        {
            var candidatos = await _repository.GetCandidatos();
            return Ok(candidatos);
        }

        [HttpGet("{id:length(24)}", Name = "GetCandidato")]
        public async Task<ActionResult<Candidato>> GetCandidatoById(string id)
        {
            var candidato = await _repository.GetCandidato(id);
            if (candidato is null)
            {
                return NotFound();
            }
            return Ok(candidato);
        }

        [HttpPost]
        public async Task<ActionResult<Candidato>> CreateCandidato([FromBody] Candidato candidato)
        {
            await _repository.CreateCandidato(candidato);

            return CreatedAtRoute("GetCandidato", new { id = candidato.Id }, candidato);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCandidato([FromBody] Candidato candidato)
        {
            return Ok(await _repository.UpdateCandidato(candidato));
        }

        [HttpDelete("{id:length(24)}", Name ="DeleteCandidato")]
        public async Task<IActionResult> DeleteCandidatoById(string id)
        {
            return Ok(await _repository.DeleteCandidato(id));
        }

    }
}
