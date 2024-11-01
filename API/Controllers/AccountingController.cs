using API.Contracts;
using Core.Abstractions;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("/accountings")]
    [ApiController]
    public class AccountingController : ControllerBase
    {
        private readonly IAccountingService accountingService;

        public AccountingController(IAccountingService accountingService)
        {
            this.accountingService = accountingService;
        }

        [HttpGet]
        public async Task<ActionResult<List<AccountingResponse>>> GetAccountings()
        {
            var accountings = await accountingService.GetAllAccountings();
            var response = accountings.Select(a => new AccountingResponse(a.Id, a.StoreId, a.Date, a.Start, a.End, a.Status, a.Description));
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateAccounting([FromBody] AccountingRequest request)
        {
            var accountingId = Guid.NewGuid();
            var (accounting, error) = Accounting.Create(accountingId, request.StoreId, request.Date, request.Description);

            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            await accountingService.CreateAccounting(accounting);
            return Ok(accountingId);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> UpdateAccounting(Guid id, [FromBody] AccountingRequest request)
        {
            var accounting = Accounting.Create(id, request.StoreId, request.Date, request.Description).Accounting;
            await accountingService.UpdateAccounting(accounting);
            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteAccounting(Guid id)
        {
            await accountingService.DeleteAccounting(id);
            return Ok();
        }
    }
}
