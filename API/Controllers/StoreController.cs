using API.Contracts;
using Core.Abstractions;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("/stores")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IStoreService storeService;

        public StoreController(IStoreService storeService)
        {
            this.storeService = storeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<StoreResponse>>> GetStores()
        {
            var stores = await storeService.GetAllStores();

            var response = stores.Select(s => new StoreResponse(s.Id, s.Address));

            return Ok(response);
        }

        [HttpPost("{id:int}")]
        public async Task<ActionResult<Guid>> CreateStore(int id, [FromBody] StoreRequest request)
        {
            var (store, error) = Store.Create(id, request.Address);

            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            var storeid = await storeService.CreateStore(store);

            return Ok(storeid);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<int>> UpdateStore(int id, [FromBody] StoreRequest request)
        {
            await storeService.UpdateStore(Store.Create(id, request.Address).Store);

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteStore(int id)
        {
            await storeService.DeleteStore(id);
            return Ok();
        }
    }
}
