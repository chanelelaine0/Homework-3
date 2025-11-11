using SPA.Domain.Entities;
using SPA.Domain.Interfaces;
using SPA.Infrastructure.Context;

namespace SPA.Infrastructure.Repositories
{
    public class ServicioRepository : BaseRepository<Servicio>, IServicioRepository
    {
        public ServicioRepository(SpaContext context) : base(context) { }
    }
}
