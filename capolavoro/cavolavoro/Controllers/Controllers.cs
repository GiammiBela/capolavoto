using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace cavolavoro.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CurrencyController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _apiKey = "49a2400c4607981bdbef8f7e"; 

        public CurrencyController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet("convert")]
        public async Task<IActionResult> ConvertCurrency([FromQuery] string from, [FromQuery] string to, [FromQuery] decimal amount)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetStringAsync($"https://v6.exchangerate-api.com/v6/{_apiKey}/latest/{from}");

            var rates = JObject.Parse(response)["conversion_rates"];
            var rate = rates[to].Value<decimal>();

            var convertedAmount = amount * rate;
            return Ok(new { amount = convertedAmount });
        }
    }
}
