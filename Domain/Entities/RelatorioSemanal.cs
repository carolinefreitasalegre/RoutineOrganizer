namespace Domain.Entities
{
    public class RelatorioSemanal
    {
        public int Id { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}

/*
RelatorioSemanal: Id, UsuarioId, SemanaInicio, SemanaFim, QuantidadeRotinas, TarefasConcluidas
 */