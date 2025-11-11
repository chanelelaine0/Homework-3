using SPA.Domain.Core;
namespace SPA.Domain.Entities
{
    public class Empleado : BaseEntity
    {
        public string Nombre { get; private set; }
        public decimal ComisionPorcentaje { get; private set; }

        public ICollection<Cita> Citas { get; private set; } = new List<Cita>();
    }
}