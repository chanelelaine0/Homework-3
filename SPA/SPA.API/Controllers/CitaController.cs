using Microsoft.AspNetCore.Mvc;
using SPA.Domain.Entities;
using SPA.Domain.Interfaces;

namespace SPA.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitaController : ControllerBase
    {
        private readonly ICitaRepository _citaRepository;

        public CitaController(ICitaRepository citaRepository)
        {
            _citaRepository = citaRepository;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var citas = await _citaRepository.GetAllAsync();
            return Ok(citas);
        }

        
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cita = await _citaRepository.GetByIdAsync(id);

            if (cita is null)
                return NotFound(new { message = "Cita no encontrada" });

            return Ok(cita);
        }

        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Cita cita)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _citaRepository.AddAsync(cita);

            return CreatedAtAction(nameof(GetById), new { id = cita.Id }, cita);
        }

        
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Cita cita)
        {
            if (id != cita.Id)
                return BadRequest(new { message = "El ID no coincide" });

            var exists = await _citaRepository.GetByIdAsync(id);

            if (exists is null)
                return NotFound(new { message = "Cita no encontrada" });

            await _citaRepository.UpdateAsync(cita);

            return NoContent();
        }

        
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var cita = await _citaRepository.GetByIdAsync(id);

            if (cita is null)
                return NotFound(new { message = "Cita no encontrada" });

            await _citaRepository.DeleteAsync(id);

            return NoContent();
        }
    }
}
