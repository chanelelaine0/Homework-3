using SPA.Domain.Entities;

namespace SPA.Domain.Interfaces;
public interface IServicioRepository
{
    Task<IEnumerable<Servicio>> GetAllAsync();
    Task<Servicio?> GetByIdAsync(int id);
    Task AddAsync(Servicio servicio);
    Task UpdateAsync(Servicio servicio);
    Task DeleteAsync(int id);
}