using Microsoft.AspNetCore.Mvc;
using Web.Api.Dominio.Entidades;
using Web.Api.Dominio.Extensoes;
using Web.Api.Dominio.Interfaces.Servicos;
using Web.Api.Dominio.Validacoes;
using Web.Api.Dominio.Validacoes.Mensagens;

namespace Web.Api.Service.Controllers
{
    [ApiController]
    [Route("api/v1/cliente/")]
    public class ClienteController : ControllerBase
    {
        private readonly IServicoCliente _cliente;
        public ClienteController(IServicoCliente cliente)
        {
            _cliente = cliente;
        }

        [HttpGet, Route("listar")]
        public async Task<IResult> Listar()
        {
            try
            {
                var resposta = await _cliente.Listar();

                return Results.Ok(resposta);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex);
            }
        }

        [HttpGet, Route("selecionar/{id}")]
        public async Task<IResult> Selecionar(Guid id)
        {
            try
            {
                var resposta = await _cliente.Selecionar(id);

                if (!resposta.encontrou)
                    return Results.BadRequest(Mensagens.CLIENTE_NAO_ENCONTRADO);
                else
                    return Results.Ok(resposta.cliente);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex);
            }
        }

        [HttpPost, Route("criar")]
        public async Task<IResult> Criar(ClienteRequest model)
        {
            try
            {
                var validacaoCliente = new ValidacaoCliente();
                var validacao = validacaoCliente.Validate(model);

                if (!validacao.IsValid)
                    return Results.BadRequest(validacao.Erros());
                else
                {
                    var resposta = await _cliente.Criar(model);

                    return Results.Created($"/selecionar/{resposta.Id}", resposta);
                }
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex);
            }
        }

        [HttpPut, Route("atualizar")]
        public async Task<IResult> Atualizar(ClienteRequest model)
        {
            try
            {
                var validacaoCliente = new ValidacaoCliente(true);
                var validacao = validacaoCliente.Validate(model);

                if (!validacao.IsValid)
                    return Results.BadRequest(validacao.Erros());
                else
                {
                    var resposta = await _cliente.Atualizar(model);

                    if (!resposta.encontrou)
                        return Results.BadRequest(Mensagens.CLIENTE_NAO_ENCONTRADO);
                    else
                        return Results.Ok(resposta.cliente);
                }
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex);
            }
        }

        [HttpDelete, Route("deletar/{id}")]
        public async Task<IResult> Deletar(Guid id)
        {
            try
            {
                var resposta = await _cliente.Deletar(id);

                if (!resposta)
                    return Results.BadRequest(Mensagens.CLIENTE_NAO_ENCONTRADO);
                else
                    return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex);
            }
        }
    }
}