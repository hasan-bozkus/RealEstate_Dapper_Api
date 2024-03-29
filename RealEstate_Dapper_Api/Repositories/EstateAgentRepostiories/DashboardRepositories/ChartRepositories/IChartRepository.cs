using RealEstate_Dapper_Api.Dtos.ChartDto;

namespace RealEstate_Dapper_Api.Repositories.EstateAgentRepostiories.DashboardRepositories.ChartRepositories
{
    public interface IChartRepository
    {
        Task<List<ResultChartDto>> Get5CityForChart();
    }
}
