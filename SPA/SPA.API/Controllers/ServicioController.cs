using Microsoft.AspNetCore.Mvc;
using SPA.Domain.Entities;
using SPA.Domain.Interfaces;

namespace SPA.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicioController : ControllerBase
    {
        private readonly IServicioRepository _servicioRepository;

        public ServicioController(IServicioRepository servicioRepository)
        {
            _servicioRepository = servicioRepository;
        }

       
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var servicios = await _servicioRepository.GetAllAsync();
            return Ok(servicios);
        }

        
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var servicio = await _servicioRepository.GetByIdAsync(id);

            if (servicio == null)
                return NotFound(new { message = "Servicio no encontrado" });

            return Ok(servicio);
        }

        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Servicio servicio)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _servicioRepository.AddAsync(servicio);

            return CreatedAtAction(nameof(GetById), new { id = servicio.Id }, servicio);
        }

        
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Servicio servicio)
        {
            if (id != servicio.Id)
                return BadRequest(new { message = "El ID no coincide" });

            var exists = await _servicioRepository.GetByIdAsync(id);

            if (exists == null)
                return NotFound(new { message = "Servicio no encontrado" });

            await _servicioRepository.UpdateAsync(servicio);

            return NoContent();
        }

        
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var exists = await _servicioRepository.GetByIdAsync(id);

            if (exists == null)
                return NotFound(new { message = "Servicio no encontrado" });

            await _servicioRepository.DeleteAsync(id);

            return NoContent();
        }
    }
}
