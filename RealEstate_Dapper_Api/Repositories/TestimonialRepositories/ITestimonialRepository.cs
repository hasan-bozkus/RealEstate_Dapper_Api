using RealEstate_Dapper_Api.Dtos.TestimonialDtos;

namespace RealEstate_Dapper_Api.Repositories.TestimonialRepositories
{
    public interface ITestimonialRepository
    {
        Task<List<ResultTestimonialDto>> GetAllTestimonial();
        Task CreateTestimonial(CreateTestimonialDto createTestimonialDto);
        Task DeleteTestimonial(int id);
        Task UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto);
        Task<GetByIDTestimonialDto> GetTestimonial(int id);
    }
}
