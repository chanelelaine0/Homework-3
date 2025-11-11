using Microsoft.AspNetCore.Mvc;
using Spa.Domain.Entities;
using Spa.Domain.Interfaces;

namespace Spa.API.Controllers
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
        public async Task<IActionResult> GetAll() => Ok(await _repo.GetAllAsync());

        [HttpPost]
        public async Task<IActionResult> Create(Cliente cliente)
        {
            await _repo.AddAsync(cliente);
            return CreatedAtAction(nameof(GetAll), new { id = cliente.Id }, cliente);
        }
    }
}
