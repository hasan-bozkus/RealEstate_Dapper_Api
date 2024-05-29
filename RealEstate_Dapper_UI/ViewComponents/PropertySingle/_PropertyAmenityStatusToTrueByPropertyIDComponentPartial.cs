using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Realestate_Dapper_UI.Dtos.PropertyAmenityDtos;

namespace Realestate_Dapper_UI.ViewComponents.PropertySingle
{
    public class _PropertyAmenityStatusToTrueByPropertyIDComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _PropertyAmenityStatusToTrueByPropertyIDComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44348/api/PropertyAmenities/ResultPropertyAmenityByStatusTrue?id=1");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultPropetyAmenityByStatusTrue>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
