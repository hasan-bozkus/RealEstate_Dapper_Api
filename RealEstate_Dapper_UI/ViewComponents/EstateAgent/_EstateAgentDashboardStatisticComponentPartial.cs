using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace Realestate_Dapper_UI.ViewComponents.EstateAgent
{
    public class _EstateAgentDashboardStatisticComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _EstateAgentDashboardStatisticComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();

            #region ProductCountByEmployeeId
            var responseMessage1 = await client.GetAsync("https://localhost:44348/api/EstateAgentDashboardStatistic/ProductCountByEmployeeId?id=1");
            var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
            ViewBag.ProductCountByEmployeeId = jsonData1;
            #endregion

            #region ProductCountByStatusTrue
            var responseMessage2 = await client.GetAsync("https://localhost:44348/api/EstateAgentDashboardStatistic/ProductCountByStatusTrue?id=1");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.ProductCountByStatusTrue = jsonData2;
            #endregion

            #region ProductCountByStatusFalse
            var responseMessage3 = await client.GetAsync("https://localhost:44348/api/EstateAgentDashboardStatistic/ProductCountByStatusFalse?id=1");
            var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
            ViewBag.ProductCountByStatusFalse = jsonData3;
            #endregion

            #region AllProductCount
            var responseMessage4 = await client.GetAsync("https://localhost:44348/api/EstateAgentDashboardStatistic/AllProductCount");
            var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();

            ViewBag.AllProductCount = jsonData4;
            #endregion

            return View();
        }
    }
}
