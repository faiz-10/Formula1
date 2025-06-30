using F1.UI.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
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
    }
}
