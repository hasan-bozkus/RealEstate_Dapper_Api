using Microsoft.AspNetCore.Mvc;

namespace Realestate_Dapper_UI.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public StatisticsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {

            var client = _httpClientFactory.CreateClient();

            #region activeCategoryCount
            var responseMessage = await client.GetAsync("https://localhost:44348/api/Statistics/ActiveCategoryCount");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            ViewBag.activeCategoryCount = jsonData;
            #endregion

            #region activeEmployeeConut
            var responseMessage2 = await client.GetAsync("https://localhost:44348/api/Statistics/ActiveEmployeeCount");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.activeEmployeeConut = jsonData2;
            #endregion

            #region apartmentCount
            var responseMessage3 = await client.GetAsync("https://localhost:44348/api/Statistics/ApartmentCount");
            var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
            ViewBag.apartmentCount = jsonData3;
            #endregion

            #region avergeProductPriceByRent
            var responseMessage4 = await client.GetAsync("https://localhost:44348/api/Statistics/AvergeProductPriceByRent");
            var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
            ViewBag.avergeProductPriceByRent = jsonData4;
            #endregion

            #region AvergeProductPriceBySale
            var responseMessage5 = await client.GetAsync("https://localhost:44348/api/Statistics/AvergeProductPriceBySale");
            var jsonData5 = await responseMessage5.Content.ReadAsStringAsync();
            ViewBag.AvergeProductPriceBySale = jsonData5;
            #endregion

            #region AvargeRoomCount
            var responseMessage6 = await client.GetAsync("https://localhost:44348/api/Statistics/AvargeRoomCount");
            var jsonData6 = await responseMessage6.Content.ReadAsStringAsync();
            ViewBag.AvargeRoomCount = jsonData6;
            #endregion

            #region CategoryCount
            var responseMessage7 = await client.GetAsync("https://localhost:44348/api/Statistics/CategoryCount");
            var jsonData7 = await responseMessage7.Content.ReadAsStringAsync();
            ViewBag.CategoryCount = jsonData7;
            #endregion

            #region CategoryNameByMaxProductCount
            var responseMessage8 = await client.GetAsync("https://localhost:44348/api/Statistics/CategoryNameByMaxProductCount");
            var jsonData8 = await responseMessage8.Content.ReadAsStringAsync();
            ViewBag.CategoryNameByMaxProductCount = jsonData8;
            #endregion

            //#region activeCategoryCount
            //var responseMessage = await client.GetAsync("https://localhost:44348/api/Statistics/ActiveCategoryCount");
            //var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //ViewBag.activeCategoryCount = jsonData;
            //#endregion

            //#region activeEmployeeConut
            //var responseMessage2 = await client.GetAsync("https://localhost:44348/api/Statistics/ActiveEmployeeCount");
            //var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            //ViewBag.activeEmployeeConut = jsonData2;
            //#endregion

            //#region apartmentCount
            //var responseMessage3 = await client.GetAsync("https://localhost:44348/api/Statistics/ApartmentCount");
            //var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
            //ViewBag.apartmentCount = jsonData3;
            //#endregion

            //#region avergeProductPriceByRent
            //var responseMessage4 = await client.GetAsync("https://localhost:44348/api/Statistics/AvergeProductPriceByRent");
            //var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
            //ViewBag.avergeProductPriceByRent = jsonData4;
            //#endregion

            //#region activeCategoryCount
            //var responseMessage = await client.GetAsync("https://localhost:44348/api/Statistics/ActiveCategoryCount");
            //var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //ViewBag.activeCategoryCount = jsonData;
            //#endregion

            //#region activeEmployeeConut
            //var responseMessage2 = await client.GetAsync("https://localhost:44348/api/Statistics/ActiveEmployeeCount");
            //var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            //ViewBag.activeEmployeeConut = jsonData2;
            //#endregion

            //#region apartmentCount
            //var responseMessage3 = await client.GetAsync("https://localhost:44348/api/Statistics/ApartmentCount");
            //var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
            //ViewBag.apartmentCount = jsonData3;
            //#endregion

            //#region avergeProductPriceByRent
            //var responseMessage4 = await client.GetAsync("https://localhost:44348/api/Statistics/AvergeProductPriceByRent");
            //var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
            //ViewBag.avergeProductPriceByRent = jsonData4;
            //#endregion
            return View();
        }
    }
}
