using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace MachineInfoMVC.Controllers

{
    public class MachineInfoController : Controller
    {
        private readonly HttpClient _httpClient;

        public MachineInfoController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IActionResult> Index()
        {

            var response = await _httpClient.GetAsync("http://localhost:8082/api/MachineInfo");
            var resultString = await response.Content.ReadAsStringAsync();
            dynamic result = JsonConvert.DeserializeObject(resultString);
            return View(result);
        }
    }
}
