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
            var novatarefa = new TarefaDomestica
            {
                Descricao = tarefa.Descricao,
                Prioridade = tarefa.Prioridade,
                DataPrevista = tarefa.DataPrevista,
                Status = tarefa.Status
            };

            _context.tarefaDomesticas.Add(novatarefa);
            await _context.SaveChangesAsync();

            return novatarefa;
        }

        public async Task<TarefaDomestica> EditarTarefaDomestica(TarefaDomestica tarefa)
        {
            var editarTarefa = await _context.tarefaDomesticas.FirstOrDefaultAsync(x => x.Id == tarefa.Id);

            editarTarefa.Descricao = tarefa.Descricao;
            editarTarefa.Prioridade = tarefa.Prioridade;
            editarTarefa.DataPrevista = tarefa.DataPrevista;
            editarTarefa.Status = tarefa.Status;

            _context.tarefaDomesticas.Update(editarTarefa);
            await _context.SaveChangesAsync();

            return editarTarefa;
        }

        public async Task<List<TarefaDomestica>> TodosTarefas()
        {
            return await _context.tarefaDomesticas.ToListAsync();
        }
    }
}
