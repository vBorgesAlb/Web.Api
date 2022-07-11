namespace Web.Api.Dominio.Entidades
{
    public class ClienteResponse
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public int Idade { get; set; }

        public static explicit operator ClienteResponse(Cliente model)
        {
            return new ClienteResponse()
            {
                Id = model.Id,
                Nome = model.Nome,
                Idade = model.Idade
            };
        }
    }
}
