using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.SubFeatureRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubFeaturesController : ControllerBase
    {
        private readonly ISubFetaureRepository _subFetaureRepository;

        public SubFeaturesController(ISubFetaureRepository subFetaureRepository)
        {
            _subFetaureRepository = subFetaureRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSubFeature()
        {
            var values = await _subFetaureRepository.GetAllSubFeatureAsync();
            return Ok(values);
        }
    }
}
