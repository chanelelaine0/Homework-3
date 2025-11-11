using SPA.Domain.Core;
namespace SPA.Domain.Entities
{
    public class Servicio : BaseEntity
    {
        public string Nombre { get; private set; }
        public decimal Precio { get; private set; }
        public TimeSpan Duracion { get; private set; }
    }
}