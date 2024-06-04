using Dapper;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos.WhoWeAreDetailDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.WhoWeAreRepository
{
    public class WhoWeAreDetailRepository : IWhoWeAreDetailRepository
    {
        private readonly Context _context;

        public WhoWeAreDetailRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateWhoWeAreDetail(CreateWhoWeAreDetailDto createWhoWeAreDto)
        {
            string query = "insert into WhoWeAreDetail (Title, SubTitle, Description1, Description2) values (@title, @subTitle, @description1, @description2)";
            var parameters = new DynamicParameters();
            parameters.Add("@title", createWhoWeAreDto.Title);
            parameters.Add("@subTitle", createWhoWeAreDto.SubTitle);
            parameters.Add("@description1", createWhoWeAreDto.Description1);
            parameters.Add("@description2", createWhoWeAreDto.Description2);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeletWhoWeareDetail(int id)
        {
            string query = "Delete From WhoWeAreDetail Where WhoWeAreID=@whoWeAreID";
            var parameters = new DynamicParameters();
            parameters.Add("@whoWeAreID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultWhoWeAreDetailDto>> GetAllWhoWeAre()
        {
            string query = "Select * From WhoWeAreDetail";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultWhoWeAreDetailDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIDWhoWeAreDetailDto> GetWhoWeAreDetail(int id)
        {
            string query = "Select * From WhoWeAreDetail Where WhoWeAreID=@whoWeAreID";
            var parameters = new DynamicParameters();
            parameters.Add("@whoWeAreID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstAsync<GetByIDWhoWeAreDetailDto>(query, parameters);
                return values;
            }
        }

        public async Task UpdateWhoWeAreDetail(UpdateWhoWeAreDetailDto updateWhoWeAreDto)
        {
            string query = "Update WhoWeAreDetail Set Title=@title, SubTitle=@subTitle, Description1=@description1, Description2=@description2 where WhoWeAreID=@whoWeAreID";
            var parameters = new DynamicParameters();
            parameters.Add("@title", updateWhoWeAreDto.Title);
            parameters.Add("@subTitle", updateWhoWeAreDto.SubTitle);
            parameters.Add("@description1", updateWhoWeAreDto.Description1);
            parameters.Add("@description2", updateWhoWeAreDto.Description2);
            parameters.Add("@whoWeAreID", updateWhoWeAreDto.WhoWeAreID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
