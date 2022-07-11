using AutoMapper;
using Web.Api.Dominio.Entidades;
using Web.Api.Dominio.Interfaces.Repositorios;
using Web.Api.Dominio.Interfaces.Servicos;

namespace Web.Api.Dominio.Servicos
{
    public class ServicoCliente : IServicoCliente
    {
        private readonly IRepositorioCliente _repositorio;
        private readonly IMapper _mapper;

        public ServicoCliente(IRepositorioCliente repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClienteResponse>> Listar()
        {
            return _mapper.Map<IEnumerable<ClienteResponse>>(await _repositorio.Listar());
        }

        public async Task<(bool encontrou, ClienteResponse cliente)> Selecionar(Guid id)
        {
            var cliente = _mapper.Map<ClienteResponse>(await _repositorio.Selecionar(id));

            if (cliente is null)
                return (false, new ClienteResponse());
            else
                return (true, cliente);
        }

        public async Task<ClienteResponse> Criar(ClienteRequest request)
        {
            var entidade = new Cliente(request);

            return _mapper.Map<ClienteResponse>(await _repositorio.Criar(entidade));
        }

        public async Task<(bool encontrou, ClienteResponse cliente)> Atualizar(ClienteRequest request)
        {
            var selecionado = await _repositorio.Selecionar(request.Id);

            if (selecionado is not null)
            {
                var cliente = new Cliente(request);
                var response = await _repositorio.Atualizar(cliente);
                return (true, _mapper.Map<ClienteResponse>(response));
            }

            return (false, new ClienteResponse());
        }

        public async Task<bool> Deletar(Guid id)
        {
            var selecionado = await _repositorio.Selecionar(id);

            if (selecionado is not null)
            {
                await _repositorio.Deletar(selecionado);
                return true;
            }

            return false;
        }
    }
}