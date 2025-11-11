using SPA.Domain.Entities;
using SPA.Domain.Interfaces;
using SPA.Infrastructure.Context;

namespace SPA.Infrastructure.Repositories
{
    public class CitaRepository : BaseRepository<Cita>, ICitaRepository
    {
        public CitaRepository(SpaContext context) : base(context) { }
    }
}
