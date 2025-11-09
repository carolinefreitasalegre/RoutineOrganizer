using Domain.Entities;

namespace Infrastructure.Interfaces
{
    public interface ITarefaDomesticaRepository
    {
        Task<TarefaDomestica> CriarTarefaDomestica(TarefaDomestica tarefa);
        Task<TarefaDomestica> EditarTarefaDomestica(TarefaDomestica tarefa);
        Task<TarefaDomestica?> BuscarTarefaDomestica(int Id);
        Task<List<TarefaDomestica>> TodosTarefas();
    }
}
