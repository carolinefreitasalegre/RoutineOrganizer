using Domain.Entities;
using Domain.Enum;

namespace Application.Dtos.Request
{
    public class TarefaRequest
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public EPrioridade Prioridade { get; set; }
        public DateTime DataPrevista { get; set; }
        public EStatus Status { get; set; }
        public int UsuarioId { get; set; }
    }
}
