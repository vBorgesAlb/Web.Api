using FluentValidation;
using Web.Api.Dominio.Entidades;

namespace Web.Api.Dominio.Validacoes
{
    public class ValidacaoCliente : AbstractValidator<ClienteRequest>
    {
        public ValidacaoCliente(bool atualizacao = false)
        {
            if (atualizacao)
                RuleFor(x => x.Id).NotNull().NotEmpty();

            RuleFor(x => x.Nome).NotNull().NotEmpty().MinimumLength(3).MaximumLength(100);
            RuleFor(x => x.Idade).NotEqual(0);
        }
    }
}
