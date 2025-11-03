using Domain.Entities;

namespace Infrastructure.Interfaces
{
    public interface ILembreteRepository
    {
        Task<Lembrete> CriarLembrete(Lembrete lembrete);
        Task<Lembrete> EditarLembrete(Lembrete lembrete);
        Task<Lembrete?> BuscarLembrete(int Id);
        Task<List<Lembrete>> TodosLembretes();
    }
}
