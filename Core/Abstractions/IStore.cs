using Core.Models;

namespace Core.Abstractions
{
    public interface IStore
    {
        Task<Store> GetById(int id);
        Task<List<Store>> GetAll();
        Task<int> Create(Store store);
        Task Update(Store store);
        Task Delete(int id);
    }
}
