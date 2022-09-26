using Dapper;
using DatabaseDemo.Entities;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace DatabaseDemo.Controllers
{
    [ApiController]
    [Route("Shopitems")]
    public class ShopitemControler : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public ShopitemControler(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("Default");
        }

        [HttpPost]
        public IActionResult Create(ShopItemEntity entity)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Execute("insert into public.actors (first_name) values (@FirstName)", new
                {
                    entity.FirstName
                });
            }
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll()
        {

            List<ShopItemEntity> list = new();
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                list = connection.Query<ShopItemEntity>("SELECT * FROM public.actors").ToList();
            }
            return Ok();
        }
    }
}
