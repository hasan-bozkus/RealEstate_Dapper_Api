using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.PopularLocationRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PopularLocationController : ControllerBase
    {
        private readonly IPopularLocalitonRepository _localitonRepository;

        public PopularLocationController(IPopularLocalitonRepository localitonRepository)
        {
            _localitonRepository = localitonRepository;
        }

        [HttpGet]
        public async Task<IActionResult> PopularLocationList()
        {
            var values = await _localitonRepository.GetAllPopularLocationAsync();
            return Ok(values);
        }
    }
}
