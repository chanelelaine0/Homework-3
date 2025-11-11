using SPA.Domain.Entities;
using SPA.Domain.Interfaces;
using SPA.Infrastructure.Context;

namespace SPA.Infrastructure.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(SpaContext context) : base(context) { }
    }
}
