using SPA.Domain.Entities;
public interface ICitaRepository
{
    Task<IEnumerable<Cita>> GetAllAsync();
    Task<Cita?> GetByIdAsync(int id);
    Task AddAsync(Cita cita);
    Task UpdateAsync(Cita cita);
    Task DeleteAsync(int id);
}