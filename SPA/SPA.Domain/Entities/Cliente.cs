using SPA.Domain.Core;
namespace SPA.Domain.Entities
{
    public class Cliente : BaseEntity
    {
        public string Nombre { get; private set; }
        public string Telefono { get; private set; }
        public string Email { get; private set; }

        public ICollection<Cita> Citas { get; private set; } = new List<Cita>();
    }
}