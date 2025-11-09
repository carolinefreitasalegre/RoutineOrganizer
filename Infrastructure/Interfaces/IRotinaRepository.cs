using Domain.Entities;

namespace Infrastructure.Interfaces
{
    public interface IRotinaRepository
    {
        Task<Rotina> CriarRotina(Rotina rotina);
        Task<Rotina> EditarRotina(Rotina rotina);
        Task<Rotina?> BuscarRotina(int id);
        Task<List<Rotina>> TodosRotinas();
    }
}
