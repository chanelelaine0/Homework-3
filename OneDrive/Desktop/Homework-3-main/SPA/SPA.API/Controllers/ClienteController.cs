using Microsoft.AspNetCore.Mvc;
using SPA.Application.Dtos;
using SPA.Application.Services;

namespace SPA.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteServices _clienteService;

        public ClienteController(ClienteServices clienteService)
        {
            _clienteService = clienteService;
        }

       
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clientes = await _clienteService.GetAllClientesAsync();
            return Ok(clientes);
        }

      
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cliente = await _clienteService.GetClienteByIdAsync(id);

            if (cliente is null)
                return NotFound(new { message = "Cliente no encontrado" });

            return Ok(cliente);
        }

       
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ClienteDto clienteDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _clienteService.CreateClienteAsync(clienteDto);

            return CreatedAtAction(nameof(GetById),
                                   new { id = created.Id },
                                   created);
        }

        
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] ClienteDto clienteDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _clienteService.UpdateClienteAsync(id, clienteDto);

            if (updated is null)
                return NotFound(new { message = "Cliente no encontrado" });

            return Ok(updated);
        }

        
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _clienteService.DeleteClienteAsync(id);

            if (!deleted)
                return NotFound(new { message = "Cliente no encontrado" });

            return NoContent();
        }
    }
}
