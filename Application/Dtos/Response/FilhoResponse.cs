using Domain.Entities;

namespace Application.Dtos.Response
{
    public class FilhoResponse
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public ICollection<Rotina> Rotinas { get; set; }
    }
}
