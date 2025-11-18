using Mapster;
using SPA.Application.Dtos;
using SPA.Domain.Entities;
using SPA.Infrastructure.Interfaces;
using SPA.Infrastructure.Context;
using SPA.Infrastructure.Interfaces;
namespace SPA.Application.Services;

public class ServicioServices
{
    private readonly IServicioRepository _servicioRepository;

    public ServicioServices(IServicioRepository servicioRepository)
    {
        _servicioRepository = servicioRepository;
    }

    public async Task<ServicioDto> GetServicioByIdAsync(int id)
    {
        var servicio = await _servicioRepository.GetByIdAsync(id);
        return servicio.Adapt<ServicioDto>();
    }

    public async Task<IEnumerable<ServicioDto>> GetAllServiciosAsync()
    {
        var servicios = await _servicioRepository.GetAllAsync();
        return servicios.Adapt<IEnumerable<ServicioDto>>();
    }

    public async Task<ServicioDto> CreateServicioAsync(ServicioDto servicioDto)
    {
        var servicio = servicioDto.Adapt<Servicio>();
        var createdServicio = await _servicioRepository.AddAsync(servicio);
        return createdServicio.Adapt<ServicioDto>();
    }

    public async Task<ServicioDto> UpdateServicioAsync(int id, ServicioDto servicioDto)
    {
        var servicio = servicioDto.Adapt<Servicio>();
        servicio.Id = id;
        var updatedServicio = await _servicioRepository.UpdateAsync(servicio);
        return updatedServicio.Adapt<ServicioDto>();
    }

    public async Task<bool> DeleteServicioAsync(int id)
    {
        return await _servicioRepository.DeleteAsync(id);
    }


}
