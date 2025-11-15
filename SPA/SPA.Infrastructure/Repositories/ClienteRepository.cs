using Microsoft.EntityFrameworkCore;
using SPA.Domain.Entities;
using SPA.Domain.Interfaces;
using SPA.Infrastructure.Context;

namespace SPA.Infrastructure.Repositories.Cliente
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        private readonly SpaContext _context;

        public ClienteRepository(SpaContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            return await _context.Clientes.ToListAsync();
        }

       
        public async Task<Cliente?> GetByIdAsync(int id)
        {
            return await _context.Clientes
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        
        public async Task AddAsync(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
        }

        
        public async Task UpdateAsync(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
        }

     
        public async Task DeleteAsync(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente is null)
                return;

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
        }
    }
}

