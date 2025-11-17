using SPA.Domain.Entities;
using SPA.Domain.Interfaces;
using SPA.Infrastructure.Context;
using  SPA.Infrastructure.Core;
using Microsoft.EntityFrameworkCore;

namespace SPA.Infrastructure.Repositories;

public class CitaRepository : ICitaRepository
{
    private readonly SpaContext _context;

    public CitaRepository(SpaContext  context)
    {
        _context = context;
    }

    
    public async Task<IEnumerable<Cita>> GetAllAsync()
    {
        return await _context.Citas
            .Include(c => c.Cliente)
            .Include(c => c.Empleado)
            .Include(c => c.Servicio)
            .ToListAsync();
    }

    
    public async Task<Cita?> GetByIdAsync(int id)
    {
        return await _context.Citas
            .Include(c => c.Cliente)
            .Include(c => c.Empleado)
            .Include(c => c.Servicio)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

        public async Task AddAsync(Cita cita)
    {
        await _context.Citas.AddAsync(cita);
        await _context.SaveChangesAsync();
    }

    
    public async Task UpdateAsync(Cita cita)
    {
        _context.Citas.Update(cita);
        await _context.SaveChangesAsync();
    }

    
    public async Task DeleteAsync(int id)
    {
        var cita = await _context.Citas.FindAsync(id);

        if (cita is null)
            return;

        _context.Citas.Remove(cita);
        await _context.SaveChangesAsync();
    }
}


