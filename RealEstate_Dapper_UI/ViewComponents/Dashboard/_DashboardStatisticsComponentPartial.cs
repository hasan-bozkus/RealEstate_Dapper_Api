using Microsoft.AspNetCore.Mvc;

namespace Realestate_Dapper_UI.ViewComponents.Dashboard
{
    public class _DashboardStatisticsComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            var client = _httpClientFactory.CreateClient();

            #region ProductCount
            var responseMessage1 = await client.GetAsync("https://localhost:44348/api/Statistics/ProductCount");
            var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
            ViewBag.ProductCount = jsonData1;
            #endregion

            #region EmployeeNameByMaxProductCount
            var responseMessage2 = await client.GetAsync("https://localhost:44348/api/Statistics/EmployeeNameByMaxProductCount");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.EmployeeNameByMaxProductCount = jsonData2;
            #endregion

            #region DifferentCityCount
            var responseMessage3 = await client.GetAsync("https://localhost:44348/api/Statistics/DifferentCityCount");
            var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
            ViewBag.DifferentCityCount = jsonData3;
            #endregion

            #region avergeProductPriceByRent
            var responseMessage4 = await client.GetAsync("https://localhost:44348/api/Statistics/AvergeProductPriceByRent");
            var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
            
            ViewBag.averageProductPriceByRent = jsonData4;
            #endregion

            return View();
        }
    }
}
