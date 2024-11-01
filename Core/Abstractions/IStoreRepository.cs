using Core.Models;

namespace Core.Abstractions
{
    public interface IStore
    {
        Task<Store> GetById(Guid id);
        Task<List<Store>> GetAll();
        Task<Guid> Create(Store store);
        Task Update(Store store);
        Task Delete(Guid id);
    }
}
