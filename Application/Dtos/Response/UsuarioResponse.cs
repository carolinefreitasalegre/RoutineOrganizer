using Domain.Entities;
using Domain.Enum;

namespace Application.Dtos.Response
{
    public class UsuarioResponse
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public ETipoPlano TipoPlano { get; set; }

        public ICollection<Filho> Filhos { get; set; }
        public ICollection<Lembrete> Lembretes { get; set; }
        public ICollection<TarefaDomestica> TarefasDomesticas { get; set; }
        //public ICollection<RelatorioSemanal> RelatoriosSemanais { get; set; }
    }
}
