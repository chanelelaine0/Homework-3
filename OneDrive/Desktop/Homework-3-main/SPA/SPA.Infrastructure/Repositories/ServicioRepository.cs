using Microsoft.EntityFrameworkCore;
using SPA.Domain.Entities;
using SPA.Domain.Interfaces;
using SPA.Infrastructure.Context;
using  SPA.Infrastructure.Core;

namespace SPA.Infrastructure.Repositories;

    public class ServicioRepository : BaseRepository<Servicio>, IServicioRepository
    {
        private readonly SpaContext _context;

        public ServicioRepository(SpaContext context) : base(context)
        {
            _context = context;
        }

        
        public async Task<IEnumerable<Servicio>> GetAllAsync()
        {
            return await _context.Servicios.ToListAsync();
        }

        
        public async Task<Servicio?> GetByIdAsync(int id)
        {
            return await _context.Servicios
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        
        public async Task AddAsync(Servicio servicio)
        {
            await _context.Servicios.AddAsync(servicio);
            await _context.SaveChangesAsync();
        }

        
        public async Task UpdateAsync(Servicio servicio)
        {
            _context.Servicios.Update(servicio);
            await _context.SaveChangesAsync(); 
           
        }

        
        public async Task DeleteAsync(int id)
        {
            var servicio = await _context.Servicios.FindAsync(id);

            if (servicio is null)
                return;

            _context.Servicios.Remove(servicio);
            await _context.SaveChangesAsync();
        }
    }

