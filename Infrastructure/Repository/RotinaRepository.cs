using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Reository
{
    public class RotinaRepository : IRotinaRepository
    {
        private readonly AppDbContext _context;

        public RotinaRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Rotina?> BuscarRotina(int id)
        {
            return await _context.rotina.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Rotina> CriarRotina(Rotina rotina)
        {
            _context.rotina.Add(rotina);
            await _context.SaveChangesAsync();

            return rotina;

        }

        public async Task<Rotina> EditarRotina(Rotina rotina)
        {
            _context.rotina.Update(rotina);
            await _context.SaveChangesAsync();

            return rotina;
        }

        public async Task<List<Rotina>> TodosRotinas()
        {
            return await _context.rotina.ToListAsync();
        }
    }
}
