namespace Web.Api.Dominio.Entidades
{
    public class Cliente
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public int Idade { get; set; }

        public Cliente() { }
        public Cliente(ClienteRequest request)
        {
            Id = request.Id != Guid.Empty ? request.Id : Guid.NewGuid();
            Nome = request.Nome;
            Idade = request.Idade;
        }
    }
}
