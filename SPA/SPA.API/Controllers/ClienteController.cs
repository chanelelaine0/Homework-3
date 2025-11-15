using Microsoft.AspNetCore.Mvc;
using Spa.Domain.Entities;
using Spa.Domain.Interfaces;

namespace SPA.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _repo;

        public ClienteController(IClienteRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _repo.GetAllAsync());

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cliente = await _repo.GetByIdAsync(id);

            if (cliente is null)
                return NotFound();

            return Ok(cliente);
        }

        
        [HttpPost]
        public async Task<IActionResult> Create(Cliente cliente)
        {
            await _repo.AddAsync(cliente);

            return CreatedAtAction(nameof(GetById),
                new { id = cliente.Id },
                cliente);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Cliente cliente)
        {
            var existing = await _repo.GetByIdAsync(id);

            if (existing is null)
                return NotFound();

            
            existing.Nombre = cliente.Nombre;
            existing.Apellido = cliente.Apellido;
            existing.Email = cliente.Email;
            existing.Telefono = cliente.Telefono;

            await _repo.UpdateAsync(existing);

            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _repo.GetByIdAsync(id);

            if (existing is null)
                return NotFound();

            await _repo.DeleteAsync(id);

            return NoContent();
        }
    }
}
