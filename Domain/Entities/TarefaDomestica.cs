using Domain.Enum;

namespace Domain.Entities
{
    public class TarefaDomestica
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public EPrioridade Prioridade { get; set; }
        public DateTime DataPrevista { get; set; }
        public EStatus Status { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
