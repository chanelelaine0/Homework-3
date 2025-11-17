using SPA.Domain.Core;
namespace SPA.Domain.Entities
{
    public class Servicio : BaseEntity
    {
        public string Nombre { get;  set; }
        public decimal Precio { get;  set; }
        public TimeSpan Duracion { get;  set; }
    }
}