using Microsoft.AspNetCore.Mvc;

namespace Realestate_Dapper_UI.ViewComponents.Layout
{
    public class _HeaderViewComponentParital : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
