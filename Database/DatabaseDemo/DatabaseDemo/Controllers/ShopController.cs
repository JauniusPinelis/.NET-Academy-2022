using DatabaseDemo.Repositories.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseDemo.Controllers
{
    [ApiController]
    [Route("Shops")]
    public class ShopController : ControllerBase
    {
        private readonly ShopRepository _shopRepository;
        private readonly ShopItemRepository _shopItemRepository;
        private readonly TagRepository _tagRepository;

        public ShopController(ShopRepository shopRepository, ShopItemRepository shopItemRepository, TagRepository tagRepository)
        {
            _shopRepository = shopRepository;
            _shopItemRepository = shopItemRepository;
            _tagRepository = tagRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var shop = await _shopRepository.GetById(id);

            shop.ShopItems = await _shopItemRepository.GetByShopId(id);
            shop.Tags = await _tagRepository.GetByShopId(id);

            return Ok(shop);
        }
    }
}
