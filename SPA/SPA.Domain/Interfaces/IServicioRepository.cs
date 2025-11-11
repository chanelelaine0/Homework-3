using SPA.Domain.Entities;
public interface IServicioRepository
{
    Task<IEnumerable<Servicio>> GetAllAsync();
    Task<Servicio?> GetByIdAsync(int id);
    Task AddAsync(Servicio servicio);
    Task UpdateAsync(Servicio eervicio);
    Task DeleteAsync(int id);
}