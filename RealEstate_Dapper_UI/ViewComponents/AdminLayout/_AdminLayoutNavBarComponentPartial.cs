using Microsoft.AspNetCore.Mvc;

namespace Realestate_Dapper_UI.ViewComponents.AdminLayout
{
    public class _AdminLayoutNavBarComponentPartial : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
