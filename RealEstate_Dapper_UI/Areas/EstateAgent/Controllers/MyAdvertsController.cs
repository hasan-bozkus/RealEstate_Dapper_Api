using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Realestate_Dapper_UI.Dtos.ProductDtos;
using Realestate_Dapper_UI.Services;

namespace Realestate_Dapper_UI.Areas.EstateAgent.Controllers
{
    [Area("EstateAgent")]
    public class MyAdvertsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;

        public MyAdvertsController(IHttpClientFactory httpClientFactory, ILoginService loginService)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
        }

        public async Task<IActionResult> Index()
        {
            var id = _loginService.GetUserId;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44348/api/Products/ProductAdvertsListByEmployee?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ReslutProductAdvertListWithCategoryByEmployeeDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
