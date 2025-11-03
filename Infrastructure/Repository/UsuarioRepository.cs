using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Reository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario?> BuscarUsuario(int Id)
        {
            return await _context.usuarios.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<Usuario> CriarUsuario(Usuario usuario)
        {
            var novoUsuario = new Usuario
            {
                Nome = usuario.Nome,
                Email = usuario.Email,
                Senha = usuario.Senha,
                Filhos = usuario.Filhos,
                TipoPlano = usuario.TipoPlano,
            };

            await _context.usuarios.AddAsync(novoUsuario);
            return novoUsuario;

        }

        public async Task<Usuario> EditarUsuario(Usuario usuario)
        {
            var editarUsuario = await _context.usuarios.FirstOrDefaultAsync(x => x.Id == usuario.Id);
            
            editarUsuario.Nome = usuario.Nome;
            editarUsuario.Lembretes = usuario.Lembretes;
            editarUsuario.Senha = usuario.Senha;
            editarUsuario.TipoPlano = usuario.TipoPlano;

            _context.usuarios.Update(editarUsuario);
            await _context.SaveChangesAsync();

            return editarUsuario;
        }

        public async Task<List<Usuario>> TodosUsuarios()
        {
            return await _context.usuarios.ToListAsync();
        }
    }
}
