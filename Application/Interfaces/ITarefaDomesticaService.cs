using Application.Dtos.Request;
using Application.Dtos.Response;

namespace Application.Interfaces
{
    public interface ITarefaDomesticaService
    {
        Task<TarefaResponse> CriarTarefaDomestica(TarefaRequest tarefa);
        Task<TarefaResponse> EditarTarefaDomestica(TarefaRequest tarefa);
        Task<TarefaResponse?> BuscarTarefaDomestica(int Id);
        Task<List<TarefaResponse>> TodosTarefas();
    }
}
