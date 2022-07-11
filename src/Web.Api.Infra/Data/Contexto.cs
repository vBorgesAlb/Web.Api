using Microsoft.EntityFrameworkCore;
using Web.Api.Dominio.Entidades;

namespace Web.Api.Infra.Data
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
    }
}
