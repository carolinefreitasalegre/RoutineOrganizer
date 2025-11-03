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
            var novoFilho = new Filho
            {
                Nome = filho.Nome,
                DataNascimento = filho.DataNascimento
            };

            _context.filhos.Add(novoFilho);
            await _context.SaveChangesAsync();

            return novoFilho;

        }

        public async Task<Filho> EditarFilho(Filho filho)
        {
            var editarFilho = await _context.filhos.FirstOrDefaultAsync(x => x.Id == filho.Id);

            editarFilho.Nome = filho.Nome;
            editarFilho.DataNascimento = filho.DataNascimento;

            _context.filhos.Update(editarFilho);
            await _context.SaveChangesAsync();

            return editarFilho;


        }

        public async Task<List<Filho>> TodosFilhos()
        {
            return await _context.filhos.ToListAsync();
        }
    }
}
