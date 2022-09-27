using DatabaseDemo.Repositories.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseDemo.Controllers
{
    [ApiController]
    [Route("Shopitems")]
    public class ShopitemControler : ControllerBase
    {
        private ShopItemRepository _shopItemRepository;

        public ShopitemControler(ShopItemRepository shopItemRepository)
        {
            _shopItemRepository = shopItemRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var entities = await _shopItemRepository.GetAllAsync();
            return Ok(entities);
        }
    }
}
