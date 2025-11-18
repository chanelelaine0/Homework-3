using SPA.Domain.Core;
namespace SPA.Domain.Entities
{
    public class Empleado : BaseEntity
    {
        public string Nombre { get;  set; }
        public decimal ComisionPorcentaje { get;  set; }

        public ICollection<Cita> Citas { get;  set; } = new List<Cita>();
    }
}