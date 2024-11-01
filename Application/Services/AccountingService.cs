using Core.Models;
using Core.Abstractions;

namespace Application.Services
{
    
    public class AccountingService : IAccountingService
    {
        private readonly IAccounting accountingRepository;

        public AccountingService(IAccounting accountingRepository)
        {
            this.accountingRepository = accountingRepository;
        }

        public async Task<Guid> CreateAccounting(Accounting accounting)
        {
            return await accountingRepository.Create(accounting);
        }

        public async Task DeleteAccounting(Guid id)
        {
            await accountingRepository.Delete(id);
        }

        public async Task<List<Accounting>> GetAllAccountings()
        {
            return await accountingRepository.GetAll();
        }

        public async Task<Accounting> GetAccountingById(Guid id)
        {
            return await accountingRepository.GetById(id);
        }

        public async Task UpdateAccounting(Accounting accounting)
        {
            await accountingRepository.Update(accounting);
        }
    }
}
