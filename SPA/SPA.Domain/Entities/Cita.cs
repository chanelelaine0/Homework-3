using SPA.Domain.Core;
namespace SPA.Domain.Entities
{
    public class Cita : BaseEntity
    {
        public int ClienteId { get; private set; }
        public int EmpleadoId { get; private set; }
        public int ServicioId { get; private set; }
        public DateTime Fecha { get; private set; }
        public bool Pagado { get; private set; }

        public Cliente Cliente { get; private set; }
        public Empleado Empleado { get; private set; }
        public Servicio Servicio { get; private set; }
    }
}
