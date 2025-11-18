using Mapster;
using SPA.Application.Dtos;
using SPA.Domain.Entities;
using SPA.Application.Interfaces;
using SPA.Infrastructure.Interfaces;
using SPA.Infrastructure.Context;
using SPA.Infrastructure.Interfaces;
namespace SPA.Application.Services;

public class CitaServices
{
    private readonly ICitaRepository _citaRepository;

    public CitaServices(ICitaRepository citaRepository)
    {
        _citaRepository = citaRepository;
    }

    public async Task<CitaDto> GetCitaByIdAsync(int id)
    {
        var cita = await _citaRepository.GetByIdAsync(id);
        return cita.Adapt<CitaDto>();
    }

    public async Task<IEnumerable<CitaDto>> GetAllCitasAsync()
    {
        var citas = await _citaRepository.GetAllAsync();
        return citas.Adapt<IEnumerable<CitaDto>>();
    }

    public async Task<CitaDto> CreateCitaAsync(CitaDto citaDto)
    {
        var cita = citaDto.Adapt<Cita>();
        var createdCita = await _citaRepository.AddAsync(cita);
        return createdCita.Adapt<CitaDto>();
    }

    public async Task<CitaDto> UpdateCitaAsync(int id, CitaDto citaDto)
    {
        var cita = citaDto.Adapt<Cita>();
        cita.Id = id;
        var updatedCita = await _citaRepository.UpdateAsync(cita);
        return updatedCita.Adapt<CitaDto>();
    }

    public async Task<bool> DeleteCitaAsync(int id)
    {
        return await _citaRepository.DeleteAsync(id);
    }


}
