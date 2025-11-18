using Microsoft.EntityFrameworkCore;
using SPA.Domain.Entities;

namespace SPA.Infrastructure.Context;

    public class SpaContext : DbContext
    {
        public SpaContext(DbContextOptions<SpaContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Cita> Citas { get; set; }
    }
