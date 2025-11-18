using Microsoft.AspNetCore.Mvc;
using SPA.Application.Dtos;
using SPA.Application.Interfaces; 
using SPA.Application.Services;   

namespace SPA.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitaController : ControllerBase
    {
        private readonly CitaServices _citaService;

        public CitaController(CitaServices citaService)
        {
            _citaService = citaService;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var citas = await _citaService.GetAllCitasAsync();
            return Ok(citas);
        }

       
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cita = await _citaService.GetCitaByIdAsync(id);

            if (cita is null)
                return NotFound(new { message = "Cita no encontrada" });

            return Ok(cita);
        }

       
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CitaDto citaDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _citaService.CreateCitaAsync(citaDto);

            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] CitaDto citaDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _citaService.UpdateCitaAsync(id, citaDto);

            if (updated is null)
                return NotFound(new { message = "Cita no encontrada" });

            return Ok(updated);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _citaService.DeleteCitaAsync(id);

            if (!deleted)
                return NotFound(new { message = "Cita no encontrada" });

            return NoContent();
        }
    }
}
