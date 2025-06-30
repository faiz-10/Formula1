using F1.UI.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace F1.UI.Controllers
{
    public class TeamsController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public TeamsController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            List<TeamDto> response = new List<TeamDto>();

            try
            {
                var client = httpClientFactory.CreateClient();

                var httpResponseMessage = await client.GetAsync("https://localhost:7203/api/teams");
                httpResponseMessage.EnsureSuccessStatusCode();

                response.AddRange(await httpResponseMessage.Content.ReadFromJsonAsync<IEnumerable<TeamDto>>());
            }
            catch (Exception e)
            {
                // Log the exception
            }

           

            return View(response);
        }
    }
}
