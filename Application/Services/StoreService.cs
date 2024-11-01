using Core.Models;
using Core.Abstractions;

namespace Application.Services
{
    
    public class StoreService : IStoreService
    {
        private readonly IStore storeRepository;

        public StoreService(IStore storeRepository)
        {
            this.storeRepository = storeRepository;
        }

        public async Task<int> CreateStore(Store store)
        {
            return await storeRepository.Create(store);
        }

        public async Task DeleteStore(int id)
        {
            await storeRepository.Delete(id);
        }

        public async Task<List<Store>> GetAllStores()
        {
            return await storeRepository.GetAll();
        }

        public async Task<Store> GetStoreById(int id)
        {
            return await storeRepository.GetById(id);
        }

        public async Task UpdateStore(Store store)
        {
            await storeRepository.Update(store);
        }
    }
}
