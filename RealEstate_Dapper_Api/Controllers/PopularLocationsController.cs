using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.PopularLocationDtos;
using RealEstate_Dapper_Api.Repositories.PopularLocationRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PopularLocationsController : ControllerBase
    {
        private readonly IPopularLocalitonRepository _localitonRepository;

        public PopularLocationsController(IPopularLocalitonRepository localitonRepository)
        {
            _localitonRepository = localitonRepository;
        }

        [HttpGet]
        public async Task<IActionResult> PopularLocationList()
        {
            var values = await _localitonRepository.GetAllPopularLocation();
            return Ok(values);
        }


        [HttpPost]
        public async Task<IActionResult> CreatePopularLocation(CreatePopularLocationDto createPopularLocationDto)
        {
            await _localitonRepository.CreatePopularLocation(createPopularLocationDto);
            return Ok("Lokasyon kısmı ekleme işlemi gerçekleşti.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePopularLocation(int id)
        {
            await _localitonRepository.DeletePopularLocation(id);
            return Ok("Lokasyon kısmı silme işlemi gerçekleşti.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePopularLocation(UpdatePopularLocationDto updatePopularLocationDto)
        {
            await _localitonRepository.UpdatePopularLocation(updatePopularLocationDto);
            return Ok("Lokasyon kısmı güncelleme işlemi gerçekleşti.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPopularLocation(int id)
        {
            var value = await _localitonRepository.GetPopularLocation(id);
            return Ok(value);
        }
    }
}
