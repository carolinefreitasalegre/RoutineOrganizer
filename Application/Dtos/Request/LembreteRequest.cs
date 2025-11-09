using Domain.Entities;

namespace Application.Dtos.Request
{
    public class LembreteRequest
    {
        public int Id { get; set; }
        public string Mensagem { get; set; }
        public DateTime DataHora { get; set; }
        public bool Visto { get; set; } = false;


        public int UsuarioId { get; set; }
    }
}
