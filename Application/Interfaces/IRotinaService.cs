using Application.Dtos.Request;
using Application.Dtos.Response;

namespace Application.Interfaces
{
    public interface IRotinaService
    {
        Task<RotinaResponse> CriarRotina(RotinaRequest request);
        Task<RotinaResponse> EditarRotina(RotinaRequest request);
        Task<RotinaResponse?> BuscarRotina(int id);
        Task<List<RotinaResponse>> TodosRotinas();
    }
}
