using Domain.Entities;

namespace Infrastructure.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario> CriarUsuario(Usuario usuario);
        Task<Usuario> EditarUsuario(Usuario usuario);
        Task<Usuario?> BuscarUsuario(int Id);
        Task<Usuario?> BuscarPorEmail(string email);
        Task<List<Usuario>> TodosUsuarios();
    }
}
