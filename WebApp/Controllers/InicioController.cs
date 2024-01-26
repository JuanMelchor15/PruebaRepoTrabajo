using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class InicioController : Controller
    {
        private readonly HttpClient _httpClient;
        public InicioController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://localhost:15360/api");
        }
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("/api/Cliente/GetCliente/1");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var Lista = JsonSerializer.Deserialize<IEnumerable<IndexModel>>(content);
                return View("Index", Lista);
            }

            return View(new List<IndexModel>());
        }
    }
}
