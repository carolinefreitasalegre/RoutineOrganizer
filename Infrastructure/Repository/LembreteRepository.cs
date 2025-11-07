using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Reository
{
    public class LembreteRepository : ILembreteRepository
    {
        private readonly AppDbContext _context;

        public LembreteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Lembrete?> BuscarLembrete(int Id)
        {
            return await _context.lembretes.FirstOrDefaultAsync(x => x.Id == Id);
        }
        
        public async Task<Lembrete> CriarLembrete(Lembrete lembrete)
        {
            _context.lembretes.Add(lembrete);
            await _context.SaveChangesAsync();
            return lembrete;
        }

        public async Task<Lembrete> EditarLembrete(Lembrete lembrete)
        {

            _context.lembretes.Update(lembrete);
            await _context.SaveChangesAsync();

            return lembrete;

        }

        public async Task<List<Lembrete>> TodosLembretes()
        {
            return await _context.lembretes.ToListAsync();
        }
    }
}
