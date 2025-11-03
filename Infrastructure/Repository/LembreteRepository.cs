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
            var novoLmbrete = new Lembrete
            {
                Mensagem = lembrete.Mensagem,
                DataHora = lembrete.DataHora,
                Visto = lembrete.Visto
            };

            _context.lembretes.Add(novoLmbrete);
            await _context.SaveChangesAsync();

            return novoLmbrete;
        }

        public async Task<Lembrete> EditarLembrete(Lembrete lembrete)
        {
            var editarLembrete = await _context.lembretes.FirstOrDefaultAsync(x => x.Id == lembrete.Id);

            editarLembrete.Mensagem = lembrete.Mensagem;
            editarLembrete.DataHora = lembrete.DataHora;
            editarLembrete.Visto = lembrete.Visto;

            _context.lembretes.Update(editarLembrete);
            await _context.SaveChangesAsync();

            return editarLembrete;

        }

        public async Task<List<Lembrete>> TodosLembretes()
        {
            return await _context.lembretes.ToListAsync();
        }
    }
}
