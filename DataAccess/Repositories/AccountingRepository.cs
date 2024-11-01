using Core.Abstractions;
using Core.Models;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class AccountingRepository : IAccounting
    {
        private readonly KpoDbContext context;

        public AccountingRepository(KpoDbContext context)
        {
            this.context = context;
        }

        public async Task<Guid> Create(Accounting accounting)
        {
            var accountingEntity = new AccountingEntity
            {
                Id = accounting.Id, 
                StoreId = accounting.StoreId,
                Date = accounting.Date,
                Start = accounting.Start,
                End = accounting.End,
                Status = accounting.Status,
                Description = accounting.Description
            };

            await context.Accountings.AddAsync(accountingEntity); 
            await context.SaveChangesAsync(); 
            return accountingEntity.Id; 
        }

        public async Task Delete(Guid id)
        {
            var accounting = await context.Accountings.FindAsync(id); 
            if (accounting != null)
            {
                context.Accountings.Remove(accounting); 
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<Accounting>> GetAll()
        {
            var accountingEntities = await context.Accountings.AsNoTracking().ToListAsync();

            var accountings = accountingEntities
                .Select(a => Accounting.Create(
                    a.Id,
                    a.StoreId,
                    a.Date,
                    a.Description).Accounting).ToList();

            return accountings;
        }

        public async Task<Accounting> GetById(Guid id)
        {
            var a = await context.Accountings.FindAsync(id);

            return Accounting.Create(
                a.Id,
                a.StoreId,
                a.Date,
                a.Description).Accounting;
        }

        public async Task Update(Accounting accounting)
        {
            var accountingEntity = await context.Accountings.FindAsync(accounting.Id);

            if (accountingEntity != null)
            {
                accountingEntity.StoreId = accounting.StoreId;
                accountingEntity.Date = accounting.Date;
                accountingEntity.Start = accounting.Start;
                accountingEntity.End = accounting.End;
                accountingEntity.Status = accounting.Status;
                accountingEntity.Description = accounting.Description;

                await context.SaveChangesAsync();
            }
        }
    }
}
