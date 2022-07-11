using Microsoft.EntityFrameworkCore;
using Web.Api.Dominio.Interfaces.Repositorios;

namespace Web.Api.Repositorio.Repositorios
{
    public class RepositorioBase<T> : IRepositorioBase<T> where T : class
    {
        private readonly DbContext _contexto;

        public RepositorioBase(DbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<IEnumerable<T>> Listar()
        {
            return await _contexto.Set<T>().ToArrayAsync();
        }

        public async Task<T> Selecionar(Guid id)
        {
            var entidade = await _contexto.Set<T>().FindAsync(id);

            if (entidade is not null)
                _contexto.Entry(entidade).State = EntityState.Detached;

            return entidade;
        }

        public async Task<T> Criar(T entidade)
        {
            await _contexto.Set<T>().AddAsync(entidade);

            await _contexto.SaveChangesAsync();

            return entidade;
        }

        public async Task<T> Atualizar(T entidade)
        {
            _contexto.Set<T>().Update(entidade);

            await _contexto.SaveChangesAsync();

            return entidade;
        }

        public async Task Deletar(T entidade)
        {
            _contexto.Set<T>().Remove(entidade);

            await _contexto.SaveChangesAsync();
        }
    }
}
