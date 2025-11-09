namespace Domain.Entities
{
    public class Rotina
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime Horario { get; set; } = DateTime.UtcNow;
        public bool NotificacaoAtiva { get; set; } = false;
        public int FilhoId { get; set; }
        public Filho Filho { get; set; }
    }
}

