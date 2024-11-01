using Core.Models;

namespace Core.Abstractions
{
    public interface IAccountingService
    {
        Task<Guid> CreateAccounting(Accounting accounting);
        Task DeleteAccounting(Guid id);
        Task<Accounting> GetAccountingById(Guid id);
        Task<List<Accounting>> GetAllAccountings();
        Task UpdateAccounting(Accounting accounting);
    }

}
