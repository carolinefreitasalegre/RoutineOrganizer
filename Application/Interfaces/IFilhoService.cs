using Application.Dtos.Request;
using Application.Dtos.Response;

namespace Application.Interfaces
{
    public interface IFilhoService
    {
        Task<FilhoResponse> CriarFilho(FilhoRequest filho);
        Task<FilhoResponse> EditarFilho(FilhoRequest filho);
        Task<FilhoResponse?> BuscarFilho(int Id);
        Task<List<FilhoResponse>> TodosFilhos();
    }
}
