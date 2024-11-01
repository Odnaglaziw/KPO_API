using Core.Abstractions;
using Core.Models;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class StoreRepository : IStore
    {
        private readonly KpoDbContext context;

        public StoreRepository(KpoDbContext context)
        {
            this.context = context;
        }

        public async Task<int> Create(Store store)
        {
            var storeEntity = new StoreEntity
            {
                Id = store.Id,
                Address = store.Address,
            };

            await context.Stores.AddAsync(storeEntity); 
            await context.SaveChangesAsync(); 
            return storeEntity.Id;
        }

        public async Task Delete(int id)
        {
            var store = await context.Stores.FindAsync(id); 
            if (store != null)
            {
                context.Stores.Remove(store); 
                await context.SaveChangesAsync(); 
            }
        }

        public async Task<List<Store>> GetAll()
        {
            var storeEntities = await context.Stores.AsNoTracking().ToListAsync();

            var stores = storeEntities
                .Select(s => Store.Create(
                    s.Id,
                    s.Address).Store).ToList(); 

            return stores; 
        }

        public async Task<Store> GetById(int id)
        {
            var s = await context.Stores.FindAsync(id); 

            return Store.Create(
                s.Id,
                s.Address).Store; 
        }

        public async Task Update(Store store)
        {
            var storeEntity = await context.Stores.FindAsync(store.Id);

            if (storeEntity != null)
            {
                storeEntity.Id = store.Id;
                storeEntity.Address = store.Address;

                await context.SaveChangesAsync(); 
            }
        }
    }
}
