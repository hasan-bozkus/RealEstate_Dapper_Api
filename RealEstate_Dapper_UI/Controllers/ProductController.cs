using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Realestate_Dapper_UI.Dtos.CategoryDtos;
using Realestate_Dapper_UI.Dtos.ProductDtos;

namespace Realestate_Dapper_UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44348/api/Products/ProductListWithCategory");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44348/api/Categories");

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);

            List<SelectListItem> categoryValues = (from x in values.ToList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.v = categoryValues;

            return View();
        }

        public async Task<IActionResult> ProductDealOfTheDayStatusChangeToFalse(int Id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44348/api/Products/ProductDealOfTheDayStatusChangeToFalse/" + Id);
            if (responseMessage.IsSuccessStatusCode)
            {
              return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> ProductDealOfTheDayStatusChangeToTrue(int Id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44348/api/Products/ProductDealOfTheDayStatusChangeToTrue/" + Id);
            if (responseMessage.IsSuccessStatusCode)
            {
              return RedirectToAction("Index");
            }
            return View();
        }
    }
}
