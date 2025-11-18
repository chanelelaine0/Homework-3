using SPA.Domain.Core;
namespace SPA.Domain.Entities
{
    public class Cliente : BaseEntity
    {
        public string Nombre { get;  set; }

        public string Apellido { get;  set; }
        public string Telefono { get;  set; }
        public string Email { get;  set; }

        public ICollection<Cita> Citas { get;  set; } = new List<Cita>();
    }
}