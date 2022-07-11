namespace Web.Api.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioBase<T> where T : class
    {
        Task<IEnumerable<T>> Listar();
        Task<T> Selecionar(Guid id);
        Task<T> Criar(T entidade);
        Task<T> Atualizar(T entidade);
        Task Deletar(T entidade);
    }
}
