using Microsoft.AspNetCore.Mvc;
using SPA.Domain.Entities;
using SPA.Domain.Interfaces;

namespace SPA.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpleadoController : ControllerBase
    {
        private readonly IEmpleadoRepository _empleadoRepository;

        public EmpleadoController(IEmpleadoRepository empleadoRepository)
        {
            _empleadoRepository = empleadoRepository;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var empleados = await _empleadoRepository.GetAllAsync();
            return Ok(empleados);
        }

        
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var empleado = await _empleadoRepository.GetByIdAsync(id);

            if (empleado == null)
                return NotFound(new { message = "Empleado no encontrado" });

            return Ok(empleado);
        }

        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Empleado empleado)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _empleadoRepository.AddAsync(empleado);

            return CreatedAtAction(nameof(GetById), new { id = empleado.Id }, empleado);
        }

        
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Empleado empleado)
        {
            if (id != empleado.Id)
                return BadRequest(new { message = "El ID no coincide" });

            var exists = await _empleadoRepository.GetByIdAsync(id);

            if (exists == null)
                return NotFound(new { message = "Empleado no encontrado" });

            await _empleadoRepository.UpdateAsync(empleado);

            return NoContent();
        }

        
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var exists = await _empleadoRepository.GetByIdAsync(id);

            if (exists == null)
                return NotFound(new { message = "Empleado no encontrado" });

            await _empleadoRepository.DeleteAsync(id);

            return NoContent();
        }
    }
}
