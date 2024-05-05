using RealEstate_Dapper_Api.Dtos.ProductImageDtos;

namespace RealEstate_Dapper_Api.Repositories.ProductImageRepositories
{
    public class ProductImageRepository : IProductImageRepository
    {
        public Task<GetProductImageByProductIDDto> GetProductImageByProductID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
