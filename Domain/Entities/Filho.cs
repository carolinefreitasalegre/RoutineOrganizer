namespace Domain.Entities
{
    public class Filho
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public ICollection<Rotina> Rotinas { get; set; }

    }
}

