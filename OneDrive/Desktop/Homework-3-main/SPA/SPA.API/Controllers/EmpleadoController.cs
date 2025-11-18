using Microsoft.AspNetCore.Mvc;
using SPA.Application.Dtos;
using SPA.Application.Services;

namespace SPA.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpleadoController : ControllerBase
    {
        private readonly EmpleadoServices _empleadoService;

        public EmpleadoController(EmpleadoServices empleadoService)
        {
            _empleadoService = empleadoService;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var empleados = await _empleadoService.GetAllEmpleadosAsync();
            return Ok(empleados);
        }

        
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var empleado = await _empleadoService.GetEmpleadoByIdAsync(id);

            if (empleado is null)
                return NotFound(new { message = "Empleado no encontrado" });

            return Ok(empleado);
        }

        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EmpleadoDto empleadoDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _empleadoService.CreateEmpleadoAsync(empleadoDto);

            return CreatedAtAction(nameof(GetById),
                                   new { id = created.Id },
                                   created);
        }

        
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] EmpleadoDto empleadoDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _empleadoService.UpdateEmpleadoAsync(id, empleadoDto);

            if (updated is null)
                return NotFound(new { message = "Empleado no encontrado" });

            return Ok(updated);
        }

        
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _empleadoService.DeleteEmpleadoAsync(id);

            if (!deleted)
                return NotFound(new { message = "Empleado no encontrado" });

            return NoContent();
        }
    }
}
