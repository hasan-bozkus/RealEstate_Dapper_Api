using RealEstate_Dapper_Api.Dtos.WhoWeAreDetailDtos;

namespace RealEstate_Dapper_Api.Repositories.WhoWeAreRepository
{
    public interface IWhoWeAreDetailRepository
    {
        Task<List<ResultWhoWeAreDetailDto>> GetAllWhoWeAre();
        Task CreateWhoWeAreDetail(CreateWhoWeAreDetailDto createWhoWeAreDto);
        Task DeletWhoWeareDetail(int id);
        Task UpdateWhoWeAreDetail(UpdateWhoWeAreDetailDto updateWhoWeAreDto);
        Task<GetByIDWhoWeAreDetailDto> GetWhoWeAreDetail(int id);
    }
}
