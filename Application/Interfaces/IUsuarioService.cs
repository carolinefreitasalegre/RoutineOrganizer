using Application.Dtos.Request;
using Application.Dtos.Response;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioResponse> CriarUsuario(UsuarioRequest usuario);
        Task<UsuarioResponse> EditarUsuario(UsuarioRequest usuario);
        Task<UsuarioResponse?> BuscarUsuario(int Id);
        Task<List<UsuarioResponse>> TodosUsuarios();
    }
}
