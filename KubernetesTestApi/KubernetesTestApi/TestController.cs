using Microsoft.AspNetCore.Mvc;

namespace KubernetesTestApi
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { });
        }
    }
}
