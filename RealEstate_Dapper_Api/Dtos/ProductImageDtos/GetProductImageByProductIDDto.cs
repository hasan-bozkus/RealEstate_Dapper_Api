namespace RealEstate_Dapper_Api.Dtos.ProductImageDtos
{
    public class GetProductImageByProductIDDto
    {
        public int ProductImageID { get; set; }
        public string ImageUrl { get; set; }
        public int ProductID { get; set; }
    }
}
