using Microsoft.AspNetCore.Mvc;

namespace Realestate_Dapper_UI.ViewComponents.EstateAgent.EstateAgentNavBar
{
    public class _EstateAgentNavBarMessageComponentPartial : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
