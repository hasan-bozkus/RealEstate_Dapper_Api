using Dapper;
using RealEstate_Dapper_Api.Dtos.PropertyAmenityDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.PropertyAmenityRepositories
{
    public class PropertyAmenityRepository : IPropertyAmenityRepository
    {
        private readonly Context _context;

        public PropertyAmenityRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultPropetyAmenityByStatusTrue>> ResultPropetyAmenityByStatusTrueAsync(int id)
        {
            var query = "Select PropertyAmenityID, Title From PropertyAmenity Inner Join Amenity On Amenity.AmenityID = PropertyAmenity.AmenityID Where PropertyID=@propertyID And Status=1";
            var parameters = new DynamicParameters();
            parameters.Add("@propertyID", id);
            using(var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultPropetyAmenityByStatusTrue>(query, parameters);
                return values.ToList();
            }
        }
    }
}
