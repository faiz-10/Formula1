using F1.UI.Models.Domains;
using F1.UI.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace F1.UI.Controllers
{
    public class DriversController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public DriversController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<DriverDto> response = new List<DriverDto>();

            try
            {
                var client = httpClientFactory.CreateClient();

                var httpResponseMessage = await client.GetAsync("https://localhost:7203/api/drivers");
                httpResponseMessage.EnsureSuccessStatusCode();

                response.AddRange(await httpResponseMessage.Content.ReadFromJsonAsync<IEnumerable<DriverDto>>());
            }
            catch (Exception e)
            {
                // Log exception
            }

            return View(response);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddDriverViewModel addDriverViewModel)
        {

            var client = httpClientFactory.CreateClient();

            var httpResponseMessage = await client.SendAsync(new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://localhost:7203/api/drivers"),
                Content = new StringContent(JsonSerializer.Serialize(addDriverViewModel), encoding:Encoding.UTF8, "application/json")
            });

            httpResponseMessage.EnsureSuccessStatusCode();

            var reponse = httpResponseMessage.Content.ReadAsStringAsync();
            if (reponse != null)
            {
                return RedirectToAction("Index", "Drivers");
            }

            return View();
        }
    }
}
