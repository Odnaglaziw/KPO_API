using Core.Models;

namespace Core.Abstractions
{
    public interface IAccounting
    {
        Task<Accounting> GetById(Guid id);
        Task<List<Accounting>> GetAll();
        Task<Guid> Create(Accounting accounting);
        Task Update(Accounting accounting);
        Task Delete(Guid id);
    }
}
