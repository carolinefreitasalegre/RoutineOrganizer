using Domain.Entities;
using Domain.Enum;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Reository
{
    public class TarefaDomesticaRepository : ITarefaDomesticaRepository
    {
        private readonly AppDbContext _context;

        public TarefaDomesticaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TarefaDomestica?> BuscarTarefaDomestica(int Id)
        {
            return await _context.tarefaDomesticas.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<TarefaDomestica> CriarTarefaDomestica(TarefaDomestica tarefa)
        {
            _context.tarefaDomesticas.Add(tarefa);
            await _context.SaveChangesAsync();

            return tarefa;
        }

        public async Task<TarefaDomestica> EditarTarefaDomestica(TarefaDomestica tarefa)
        {
            _context.tarefaDomesticas.Update(tarefa);
            await _context.SaveChangesAsync();

            return tarefa;
        }

        public async Task<List<TarefaDomestica>> TodosTarefas()
        {
            return await _context.tarefaDomesticas.ToListAsync();
        }
    }
}
