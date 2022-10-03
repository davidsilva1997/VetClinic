using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace VetClinicWeb.Controllers
{
    public class VetController : Controller
    {
        static readonly HttpClient httpClient = new HttpClient();

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync("https://localhost:7012/Vet");
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadFromJsonAsync<IEnumerable<Models.Vet>>();

                return View(responseBody);
            }
            catch (HttpRequestException e)
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetVet([FromRoute] Guid id)
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(string.Format("{0}/{1}", "https://localhost:7012/Vet", id));
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadFromJsonAsync<Models.Vet>();

                return View(responseBody);
            }
            catch (HttpRequestException e)
            {
                return NotFound();
            }
        }
    }
}
