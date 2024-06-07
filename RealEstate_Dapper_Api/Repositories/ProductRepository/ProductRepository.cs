using Dapper;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.ProductDetailDtos;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ProductRepository
{
    public class ProductRepository : IProductRepository
    {

        private readonly Context _context;

        public ProductRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateProduct(CreateProductDto createProductDto)
        {
            string query = "insert into Product (Title, Price, Dİstrict, City, CoverImage, Address, Description, Type, DealOfTheDay, AdvertisementDate, ProductStatus, ProductCategory, EmployeeID) values (@Title, @Price, @Dİstrict, @City, @CoverImage, @Address, @Description, @Type, @DealOfTheDay, @AdvertisementDate, @ProductStatus, @ProductCategory, @EmployeeID)";
            var parameters = new DynamicParameters();
            parameters.Add("@Title", createProductDto.Title);
            parameters.Add("@Price", createProductDto.Price);
            parameters.Add("@Dİstrict", createProductDto.Dİstrict);
            parameters.Add("@City", createProductDto.City);
            parameters.Add("@CoverImage", createProductDto.CoverImage);
            parameters.Add("@Address", createProductDto.Address);
            parameters.Add("@Description", createProductDto.Description);
            parameters.Add("@Type", createProductDto.Type);
            parameters.Add("@DealOfTheDay", createProductDto.DealOfTheDay);
            parameters.Add("@AdvertisementDate", createProductDto.AdvertisementDate);
            parameters.Add("@ProductStatus", createProductDto.ProductStatus);
            parameters.Add("@ProductCategory", createProductDto.ProductCategory);
            parameters.Add("@EmployeeID", createProductDto.EmployeeID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            string query = "Select * From Product";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync()
        {
            string query = "Select ProductID, Title, Price, City, Dİstrict, CategoryName, Type, CoverImage, Address, DealOfTheDay, SlugUrl From Product inner join Category on Product.ProductCategory=Category.CategoryID";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultLast3ProductWithCategoryDto>> GetLast3ProductAsync()
        {
            string query = "Select Top(3) ProductID,Title,Price,City,Dİstrict,ProductCategory,CategoryName,AdvertisementDate, CoverImage, Description From Product Inner Join Category On Product.ProductCategory=Category.CategoryID Order By ProductID Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultLast3ProductWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultLast5ProductWithCategoryDto>> GetLast5ProductAsync()
        {
            string query = "Select Top(5) ProductID,Title,Price,City,Dİstrict,ProductCategory,CategoryName,AdvertisementDate From Product Inner Join Category On Product.ProductCategory=Category.CategoryID Where Type='Kiralık' Order By ProductID Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultLast5ProductWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ReslutProductAdvertListWithCategoryByEmployeeDto>> GetProductAdvertListByEmployeeAsyncByFalse(int id)
        {
            string query = "Select ProductID, Title, Price, City, Dİstrict, CategoryName, Type, CoverImage, Address, DealOfTheDay From Product inner join Category on Product.ProductCategory=Category.CategoryID Where EmployeeID=@EmployeeID and ProductStatus=0";

            var parameters = new DynamicParameters();
            parameters.Add("@EmployeeID", id);

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ReslutProductAdvertListWithCategoryByEmployeeDto>(query, parameters);
                return values.ToList();
            }
        }

        public async Task<List<ReslutProductAdvertListWithCategoryByEmployeeDto>> GetProductAdvertListByEmployeeAsyncByTrue(int id)
        {
            string query = "Select ProductID, Title, Price, City, Dİstrict, CategoryName, Type, CoverImage, Address, DealOfTheDay From Product inner join Category on Product.ProductCategory=Category.CategoryID Where EmployeeID=@EmployeeID and ProductStatus=1";

            var parameters = new DynamicParameters();
            parameters.Add("@EmployeeID", id);

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ReslutProductAdvertListWithCategoryByEmployeeDto>(query, parameters);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductWithCategoryDto>> GetProductByDealOfTheDayTrueWithCategoryAsync()
        {
            string query = "Select ProductID, Title, Price, City, Dİstrict, CategoryName, Type, CoverImage, Address, DealOfTheDay From Product inner join Category on Product.ProductCategory=Category.CategoryID where DealOfTheDay=1";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetProductByProductIdDto> GetProductByProductId(int id)
        {
            string query = "Select ProductID, Title, Price, City, Dİstrict, Description, CategoryName, Type, CoverImage, Address, DealOfTheDay, AdvertisementDate, SlugUrl From Product inner join Category on Product.ProductCategory=Category.CategoryID where ProductID=@productID";
            var parameters = new DynamicParameters();
            parameters.Add("@productID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<GetProductByProductIdDto>(query, parameters);
                return values.FirstOrDefault();
            }
        }

        public async Task<GetProductDetailByIdDto> GetProductDetailByProductId(int id)
        {
            string query = "Select * From ProductDetails Where ProductID=@productID";
            var parameters = new DynamicParameters();
            parameters.Add("@productID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<GetProductDetailByIdDto>(query, parameters);
                return values.FirstOrDefault();
            }
        }

        public async Task ProductDealOfTheDayStatusChangeToFalse(int id)
        {
            string query = "Update Product Set DealOfTheDay=0 where ProductID=@productID";
            var parameters = new DynamicParameters();
            parameters.Add("@productID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task ProductDealOfTheDayStatusChangeToTrue(int id)
        {
            string query = "Update Product Set DealOfTheDay=1 where ProductID=@productID";
            var parameters = new DynamicParameters();
            parameters.Add("@productID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultProductWithSearchListDto>> ResultProductWithSearchList(string searchKeyValue, int propertyCategoryID, string city)
        {
            string query = "Select * From Product Where Title like '%" + searchKeyValue + "%' And ProductCategory=@propertyCategoryID And City=@city";
            var parameters = new DynamicParameters();
            parameters.Add("@searchKeyValue", searchKeyValue);
            parameters.Add("@propertyCategoryID", propertyCategoryID);
            parameters.Add("@city", city);
            using (var conneciton = _context.CreateConnection())
            {
                var values = await conneciton.QueryAsync<ResultProductWithSearchListDto>(query, parameters);
                return values.ToList();
            }
        }
    }
}
