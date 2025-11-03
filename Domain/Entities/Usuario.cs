using Domain.Enum;

namespace Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public ETipoPlano TipoPlano { get; set; }

        public ICollection<Filho> Filhos { get; set; }
        public ICollection<Lembrete> Lembretes { get; set; }
        public ICollection<TarefaDomestica> TarefasDomesticas { get; set; }
        public ICollection<RelatorioSemanal> RelatoriosSemanais { get; set; }
    }
}
