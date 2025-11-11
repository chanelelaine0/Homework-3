using SPA.Domain.Entities;
using SPA.Domain.Interfaces;
using SPA.Infrastructure.Context;

namespace SPA.Infrastructure.Repositories
{
    public class EmpleadoRepository : BaseRepository<Empleado>, IEmpleadoRepository
    {
        public EmpleadoRepository(SpaContext context) : base(context) { }
    }
}
