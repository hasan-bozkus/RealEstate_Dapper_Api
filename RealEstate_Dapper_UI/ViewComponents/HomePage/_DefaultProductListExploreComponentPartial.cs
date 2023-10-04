using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Realestate_Dapper_UI.Dtos.PopularLocationDtos;

namespace Realestate_Dapper_UI.ViewComponents.HomePage
{
    public class _DefaultProductListExploreComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultProductListExploreComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44348/api/PopularLocation");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultPopularLocationDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
