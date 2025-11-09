using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Reository
{
    public class FilhoRepository : IFilhoRepository
    {
        private readonly AppDbContext _context;

        public FilhoRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Filho?> BuscarFilho(int Id)
        {
            return await _context.filhos.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<Filho> CriarFilho(Filho filho)
        {
            _context.filhos.Add(filho);
             await _context.SaveChangesAsync();

            return filho;
        }

        public async Task<Filho> EditarFilho(Filho filho)
        {
            //var editarFilho = await _context.filhos.FirstOrDefaultAsync(x => x.Id == filho.Id);

            _context.filhos.Update(filho);
            await _context.SaveChangesAsync();

            return filho;


        }

        public async Task<List<Filho>> TodosFilhos()
        {
            return await _context.filhos.ToListAsync();
        }
    }
}
