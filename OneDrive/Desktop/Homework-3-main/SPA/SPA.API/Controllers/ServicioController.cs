using Microsoft.AspNetCore.Mvc;
using SPA.Application.Dtos;
using SPA.Application.Services;

namespace SPA.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicioController : ControllerBase
    {
        private readonly ServicioServices _servicioService;

        public ServicioController(ServicioServices servicioService)
        {
            _servicioService = servicioService;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var servicios = await _servicioService.GetAllServiciosAsync();
            return Ok(servicios);
        }

        
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var servicio = await _servicioService.GetServicioByIdAsync(id);

            if (servicio is null)
                return NotFound(new { message = "Servicio no encontrado" });

            return Ok(servicio);
        }

        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ServicioDto servicioDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _servicioService.CreateServicioAsync(servicioDto);

            return CreatedAtAction(nameof(GetById),
                                   new { id = created.Id },
                                   created);
        }

        
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] ServicioDto servicioDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _servicioService.UpdateServicioAsync(id, servicioDto);

            if (updated is null)
                return NotFound(new { message = "Servicio no encontrado" });

            return Ok(updated);
        }

        
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _servicioService.DeleteServicioAsync(id);

            if (!deleted)
                return NotFound(new { message = "Servicio no encontrado" });

            return NoContent();
        }
    }
}
