using Domain.Entities;
using Domain.Enum;

namespace Application.Dtos.Request
{
    public class UsuarioRequest
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public ETipoPlano TipoPlano { get; set; }
 
    }
}
