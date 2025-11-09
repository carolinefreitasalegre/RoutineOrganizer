using Application.Dtos.Request;
using Application.Dtos.Response;

namespace Application.Interfaces
{
    public interface ILembreteService
    {
        Task<LembreteResponse> CriarLembrete(LembreteRequest request);
        Task<LembreteResponse> EditarLembrete(LembreteRequest request);
        Task<LembreteResponse?> BuscarLembrete(int Id);
        Task<List<LembreteResponse>> TodosLembretes();
    }
}
