using SPA.Domain.Entities;
public interface IEmpleadoRepository
{
    Task<IEnumerable<Empleado>> GetAllAsync();
    Task<Empleado?> GetByIdAsync(int id);
    Task AddAsync(Empleado empleado);
    Task UpdateAsync(Empleado empleado);
    Task DeleteAsync(int id);
}