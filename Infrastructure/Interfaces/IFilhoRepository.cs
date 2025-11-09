using Domain.Entities;

namespace Infrastructure.Interfaces
{
    public interface IFilhoRepository
    {
        Task<Filho> CriarFilho(Filho filho);
        Task<Filho> EditarFilho(Filho filho);
        Task<Filho?> BuscarFilho(int Id);
        Task<List<Filho>> TodosFilhos();
    }
}
