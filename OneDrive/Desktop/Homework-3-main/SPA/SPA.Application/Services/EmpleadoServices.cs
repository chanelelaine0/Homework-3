using Mapster;
using SPA.Application.Dtos;
using SPA.Domain.Entities;
using SPA.Application.Interfaces;
using SPA.Infrastructure.Interfaces;
using SPA.Infrastructure.Context;
using SPA.Infrastructure.Interfaces;
namespace SPA.Application.Services;

public class EmpleadoServices
{
    private readonly IEmpleadoRepository _empleadoRepository;

    public EmpleadoServices(IEmpleadoRepository empleadoRepository)
    {
        _empleadoRepository = empleadoRepository;
    }

    public async Task<EmpleadoDto> GetEmpleadoByIdAsync(int id)
    {
        var empleado = await _empleadoRepository.GetByIdAsync(id);
        return empleado.Adapt<EmpleadoDto>();
    }

    public async Task<IEnumerable<EmpleadoDto>> GetAllEmpleadosAsync()
    {
        var empleados = await _empleadoRepository.GetAllAsync();
        return empleados.Adapt<IEnumerable<EmpleadoDto>>();
    }

    public async Task<EmpleadoDto> CreateEmpleadoAsync(EmpleadoDto empleadoDto)
    {
        var empleado = empleadoDto.Adapt<Empleado>();
        var createdEmpleado = await _empleadoRepository.AddAsync(empleado);
        return createdEmpleado.Adapt<EmpleadoDto>();
    }

    public async Task<EmpleadoDto> UpdateEmpleadoAsync(int id, EmpleadoDto empleadoDto)
    {
        var empleado = empleadoDto.Adapt<Empleado>();
        empleado.Id = id;
        var updatedEmpleado = await _empleadoRepository.UpdateAsync(empleado);
        return updatedEmpleado.Adapt<EmpleadoDto>();
    }

    public async Task<bool> DeleteEmpleadoAsync(int id)
    {
        return await _empleadoRepository.DeleteAsync(id);
    }


}
