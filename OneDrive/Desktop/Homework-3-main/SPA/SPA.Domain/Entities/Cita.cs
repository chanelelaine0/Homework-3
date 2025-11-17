using SPA.Domain.Core;
namespace SPA.Domain.Entities
{
    public class Cita : BaseEntity
    {
        public int ClienteId { get;  set; }
        public int EmpleadoId { get;  set; }
        public int ServicioId { get;  set; }
        public DateTime Fecha { get;  set; }
        public bool Pagado { get;  set; }

        public Cliente Cliente { get;  set; }
        public Empleado Empleado { get;  set; }
        public Servicio Servicio { get;  set; }
    }
}
