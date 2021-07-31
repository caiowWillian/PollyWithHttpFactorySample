using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebAPi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TesteController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TesteController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var client = _httpClientFactory.CreateClient("Teste");
            var q = client.Timeout;
            var response = await client.GetAsync("Teste");
            return Ok(await response.Content.ReadAsStringAsync());
        }
    }
}