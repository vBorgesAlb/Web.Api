using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Web.Api.Dominio.Interfaces.Repositorios;
using Web.Api.Dominio.Interfaces.Servicos;
using Web.Api.Dominio.Servicos;
using Web.Api.Infra.Data;
using Web.Api.Repositorio.Repositorios;

namespace Web.Api.Infra.IOC
{
    public static class Dependencias
    {
        public static void Adicionar(IServiceCollection services, IConfiguration configuration)
        {
            Configuracao(services, configuration);
            Servicos(services);
            Repositorios(services);
        }

        private static void Configuracao(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DbContext, Contexto>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        private static void Servicos(IServiceCollection services)
        {
            services.AddScoped<IServicoCliente, ServicoCliente>();
        }

        private static void Repositorios(IServiceCollection services)
        {
            services.AddScoped(typeof(IRepositorioBase<>), typeof(RepositorioBase<>));
            services.AddScoped<IRepositorioCliente, RepositorioCliente>();
        }
    }
}
