using Mapster;
using SPA.Application.Dtos;
using SPA.Domain.Entities;
using SPA.Application.Interfaces;
using SPA.Infrastructure.Interfaces;
using SPA.Infrastructure.Context;
using SPA.Infrastructure.Interfaces;
namespace SPA.Application.Services;

public class ClienteServices
{
    private readonly IClienteRepository _clienteRepository;

    public ClienteServices(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task<ClienteDto> GetClienteByIdAsync(int id)
    {
        var cliente = await _clienteRepository.GetByIdAsync(id);
        return cliente.Adapt<ClienteDto>();
    }

    public async Task<IEnumerable<ClienteDto>> GetAllClientesAsync()
    {
        var clientes = await _clienteRepository.GetAllAsync();
        return clientes.Adapt<IEnumerable<ClienteDto>>();
    }

    public async Task<ClienteDto> CreateClienteAsync(ClienteDto clienteDto)
    {
        var cliente = clienteDto.Adapt<Cliente>();
        var createdCliente = await _clienteRepository.AddAsync(cliente);
        return createdCliente.Adapt<ClienteDto>();
    }

    public async Task<ClienteDto> UpdateClienteAsync(int id, ClienteDto clienteDto)
    {
        var cliente = clienteDto.Adapt<Cliente>();
        cliente.Id = id;
        var updatedCliente = await _clienteRepository.UpdateAsync(cliente);
        return updatedCliente.Adapt<ClienteDto>();
    }

    public async Task<bool> DeleteClienteAsync(int id)
    {
        return await _clienteRepository.DeleteAsync(id);
    }


}
