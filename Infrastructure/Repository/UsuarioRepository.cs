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

        public async Task<Usuario?> BuscarPorEmail(string email)
        {
            return await _context.usuarios.FirstOrDefaultAsync(x => x.Email == email);
        }


        public async Task<Usuario> CriarUsuario(Usuario usuario)
        {
            
            await _context.usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
            return usuario;

        }

        public async Task<Usuario> EditarUsuario(Usuario usuario)
        {
            _context.usuarios.Update(usuario);
            await _context.SaveChangesAsync();

            return usuario;
        }

        public async Task<List<Usuario>> TodosUsuarios()
        {
            return await _context.usuarios.ToListAsync();
        }
    }
}
