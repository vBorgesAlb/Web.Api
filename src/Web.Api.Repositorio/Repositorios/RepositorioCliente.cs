using Microsoft.EntityFrameworkCore;
using Web.Api.Dominio.Entidades;
using Web.Api.Dominio.Interfaces.Repositorios;

namespace Web.Api.Repositorio.Repositorios
{
    public class RepositorioCliente : RepositorioBase<Cliente>, IRepositorioCliente
    {
        private readonly DbContext _contexto;

        public RepositorioCliente(DbContext contexto) : base(contexto)
        {
            _contexto = contexto;
        }
    }
}