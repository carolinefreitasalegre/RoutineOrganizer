using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> usuarios {get;set;}
        public DbSet<Lembrete> lembretes {get;set;}
        public DbSet<Filho> filhos {get;set;}
        public DbSet<Rotina> rotina {get;set;}
        public DbSet<TarefaDomestica> tarefaDomesticas {get;set;}

    }
}
