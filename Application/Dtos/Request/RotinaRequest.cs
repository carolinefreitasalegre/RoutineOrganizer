using Domain.Entities;

namespace Application.Dtos.Request
{
    public class RotinaRequest
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime Horario { get; set; } 
        public bool NotificacaoAtiva { get; set; } = false;
        public int FilhoId { get; set; }
    }
}
