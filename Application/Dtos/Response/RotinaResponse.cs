using Domain.Entities;

namespace Application.Dtos.Response
{
    public class RotinaResponse
    {
        public string Titulo { get; set; }
        public DateTime Horario { get; set; } = DateTime.UtcNow;
        public bool NotificacaoAtiva { get; set; } = false;
        public int FilhoId { get; set; }

    }
}
