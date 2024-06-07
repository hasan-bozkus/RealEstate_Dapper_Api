using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Realestate_Dapper_UI.Dtos.ProductDetailDtos;
using Realestate_Dapper_UI.Dtos.ProductDtos;

namespace Realestate_Dapper_UI.Controllers
{
    public class PropertyController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public PropertyController(IHttpClientFactory httpClientFactory)
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

        public async Task<IActionResult> PropertyListWithSearch(string searchKeyValue, int propertyCategoryID, string city)
        {
            ViewBag.searchKeyValue = TempData["searchKeyValue"];
            ViewBag.propertyCategoryID = TempData["propertyCategoryID"];
            ViewBag.city = TempData["city"];

            searchKeyValue = TempData["searchKeyValue"].ToString();
            propertyCategoryID = int.Parse(TempData["propertyCategoryID"].ToString());
            city = TempData["city"].ToString();

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44348/api/Products/ResultProductWithSearchList?searchKeyValue={searchKeyValue}&propertyCategoryID={propertyCategoryID}&city={city}");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductWithSearchListDto>>(jsonData);
                return PartialView(values);
            }
            return View();
        }

        [HttpGet("property/{slug}/{id}")]
        public async Task<IActionResult> PropertySingle(string slug, int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:44348/api/Products/GetProductByProductId?id=" + id);
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<ResultProductDto>(jsonData);

            var responseMessage2 = await client.GetAsync("https://localhost:44348/api/ProductDetails/GetProductDetailByProductId?id=" + id);
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            var values2 = JsonConvert.DeserializeObject<GetProductDetailByIDDto>(jsonData2);

            ViewBag.productID = values.ProductID;
            ViewBag.titles = values.Title;
            ViewBag.slugUrl = values.SlugUrl;
            ViewBag.price = values.Price;
            ViewBag.city = values.City;
            ViewBag.district = values.Dİstrict;
            ViewBag.address = values.Address;
            ViewBag.type = values.Type;
            ViewBag.Description = values.Description;
            ViewBag.advertisementDate = values.AdvertisementDate;

            DateTime nowtime = DateTime.Now;
            DateTime adrvertisementdates = values.AdvertisementDate;

            TimeSpan timeSpan = nowtime - adrvertisementdates;
            int month = timeSpan.Days;
            ViewBag.datediff = month / 30;

            ViewBag.bathCount = values2.BathCount;
            ViewBag.bedcount = values2.BedRoomCount;
            ViewBag.size = values2.ProductSize;
            ViewBag.roomCount = values2.RoomCount;
            ViewBag.garageSize = values2.GarageSize;
            ViewBag.buildYear = values2.BuildYear;
            ViewBag.location = values2.Location;
            ViewBag.video = values2.VideoUrl;

            string slugFromTitle = CreateSlug(values.Title);

            ViewBag.slugUrl = slugFromTitle;

            return View();
        }

        private string CreateSlug(string title)
        {
            title = title.ToLowerInvariant(); //küçük harfe çevir
            title = title.Replace(" ", "-"); //boşlukları tire ile değiştir
            title = System.Text.RegularExpressions.Regex.Replace(title, @"[^a-z0-9\s-]", ""); //geçersiz karakterleri kaldır
            title = System.Text.RegularExpressions.Regex.Replace(title, @"\s+", " "); //birden fazla boşluğu tek boşluğa indir ve kenar boşluklarını kaldır
            title = System.Text.RegularExpressions.Regex.Replace(title, @"\s", "-"); //boşlukları tire ile değiştir

            return title;
        }

    }
}
