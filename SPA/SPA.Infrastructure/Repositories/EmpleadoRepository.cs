using Microsoft.EntityFrameworkCore;
using SPA.Domain.Entities;
using SPA.Domain.Interfaces;
using SPA.Infrastructure.Context;

namespace SPA.Infrastructure.Repositories.Empleado
{
    public class EmpleadoRepository : BaseRepository<Empleado>, IEmpleadoRepository
    {
        private readonly SpaContext _context;

        public EmpleadoRepository(SpaContext context) : base(context)
        {
            _context = context;
        }

        
        public async Task<IEnumerable<Empleado>> GetAllAsync()
        {
            return await _context.Empleados.ToListAsync();
        }

        
        public async Task<Empleado?> GetByIdAsync(int id)
        {
            return await _context.Empleados
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        
        public async Task AddAsync(Empleado empleado)
        {
            await _context.Empleados.AddAsync(empleado);
            await _context.SaveChangesAsync();
        }

       
        public async Task UpdateAsync(Empleado empleado)
        {
            _context.Empleados.Update(empleado);
            await _context.SaveChangesAsync();
        }

        
        public async Task DeleteAsync(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);

            if (empleado is null)
                return;

            _context.Empleados.Remove(empleado);
            await _context.SaveChangesAsync();
        }
    }
}
