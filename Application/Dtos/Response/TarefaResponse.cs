using Domain.Entities;
using Domain.Enum;

namespace Application.Dtos.Response
{
    public class TarefaResponse
    {
        public string Descricao { get; set; }
        public EPrioridade Prioridade { get; set; }
        public DateTime DataPrevista { get; set; }
        public EStatus Status { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
