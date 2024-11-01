using Core.Models;

namespace Core.Abstractions
{
    public interface IStoreService
    {
        Task<int> CreateStore(Store store);
        Task DeleteStore(int id);
        Task<List<Store>> GetAllStores();
        Task<Store> GetStoreById(int id);
        Task UpdateStore(Store store);
    }

}
