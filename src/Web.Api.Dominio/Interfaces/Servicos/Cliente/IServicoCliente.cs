using Web.Api.Dominio.Entidades;

namespace Web.Api.Dominio.Interfaces.Servicos
{
    public interface IServicoCliente : IServicoBase
    {
        Task<IEnumerable<ClienteResponse>> Listar();
        Task<(bool encontrou, ClienteResponse cliente)> Selecionar(Guid id);
        Task<ClienteResponse> Criar(ClienteRequest model);
        Task<(bool encontrou, ClienteResponse cliente)> Atualizar(ClienteRequest model);
        Task<bool> Deletar(Guid id);
    }
}
