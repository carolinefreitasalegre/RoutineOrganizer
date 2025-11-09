using Domain.Entities;

namespace Application.Dtos.Response
{
    public class LembreteResponse
    {
        public string Mensagem { get; set; }
        public DateTime DataHora { get; set; }
        public bool Visto { get; set; } = false;


        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
