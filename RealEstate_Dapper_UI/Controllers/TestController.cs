using Microsoft.AspNetCore.Mvc;

namespace Realestate_Dapper_UI.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
