using AutoMapper;
using Web.Api.Dominio.Entidades;

namespace Web.Api.Infra.AutoMapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Cliente, ClienteResponse>();
        }
    }
}
