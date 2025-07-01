using F1.UI.Models.Domains;
using F1.UI.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;
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

        [HttpGet]
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

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddTeamViewModel addTeamViewModel)
        {
            var client = httpClientFactory.CreateClient();

            var httpReponseMessage = await client.SendAsync(new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://localhost:7203/api/teams"),
                Content = new StringContent(JsonSerializer.Serialize(addTeamViewModel), encoding: Encoding.UTF8, "application/json")
            });

            httpReponseMessage.EnsureSuccessStatusCode();

            var response = await httpReponseMessage.Content.ReadAsStringAsync();
            if (response != null) 
            {
                return RedirectToAction("Index", "Teams");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var client = httpClientFactory.CreateClient();

            var reponseObj = await client.GetFromJsonAsync<TeamDto>($"https://localhost:7203/api/teams/{id}");

            if (reponseObj != null) 
            {
                return View(reponseObj);
            }

            return View(null);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TeamDto teamDto)
        {
            var client = httpClientFactory.CreateClient();

            var httpResponseMessage = await client.SendAsync(new HttpRequestMessage()
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri($"https://localhost:7203/api/teams/{teamDto.Id}"),
                Content = new StringContent(JsonSerializer.Serialize(teamDto), encoding: Encoding.UTF8, "application/json")
            });

            httpResponseMessage.EnsureSuccessStatusCode();

            var response = httpResponseMessage.Content.ReadFromJsonAsync<TeamDto>();

            if (response != null) 
            {
                return RedirectToAction("Index", "Teams");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(TeamDto teamDto)
        {
            var client = httpClientFactory.CreateClient();

            var httpResponseMessage = await client.DeleteAsync(new Uri($"https://localhost:7203/api/teams/{teamDto.Id}"));

            httpResponseMessage.EnsureSuccessStatusCode();

            var response = httpResponseMessage.Content.ReadFromJsonAsync<TeamDto>();

            if(response != null)
            {
                return RedirectToAction("Index", "Teams");
            }

            return View("Edit", "Teams");
        }
    }
}
