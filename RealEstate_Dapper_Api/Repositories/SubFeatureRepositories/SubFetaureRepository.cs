using Dapper;
using RealEstate_Dapper_Api.Dtos.SubFeatureDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.SubFeatureRepositories
{
    public class SubFetaureRepository : ISubFetaureRepository
    {
        private readonly Context _context;

        public SubFetaureRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultSubFeatureDto>> GetAllSubFeatureAsync()
        {
            string query = "Select * From SubFeature";
            using (var conneciton = _context.CreateConnection())
            {
                var values = await conneciton.QueryAsync<ResultSubFeatureDto>(query);
                return values.ToList();
            }
        }
    }
}
