using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Realestate_Dapper_UI.Dtos.CategoryDtos;

namespace Realestate_Dapper_UI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        //[HttpGet]
        //public async Task<PartialViewResult> PartialSearch()
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var responseMessage = await client.GetAsync("https://localhost:44348/api/Categories");
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        //        var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
        //        return PartialView(values);
        //    }
        //    return PartialView();
        //}

        [HttpPost]
        public IActionResult PartialSearch(string searchKeyValue, string city, int propertyCategoryID)
        {
            TempData["searchKeyValue"] = searchKeyValue;
            TempData["city"] = city;
            TempData["propertyCategoryID"] = propertyCategoryID;
            return RedirectToAction("PropertyListWithSearch", "Property");
        }
    }
}
