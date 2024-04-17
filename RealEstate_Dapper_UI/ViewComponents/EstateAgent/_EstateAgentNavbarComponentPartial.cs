using Microsoft.AspNetCore.Mvc;

namespace Realestate_Dapper_UI.ViewComponents.EstateAgent
{
    public class _EstateAgentNavbarComponentPartial : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
