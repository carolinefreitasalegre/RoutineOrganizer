using Domain.Entities;

namespace Application.Dtos.Request
{
    public class FilhoRequest
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public int UsuarioId { get; set; }
    }
}
