using RealEstate_Dapper_Api.Dtos.MessageDtos;

namespace RealEstate_Dapper_Api.Repositories.MessageRepositories
{
    public interface IMessageRepository
    {
        Task<List<ResultInoxMessageDto>> GetInBoxLast3MessageListByReceive(int id);
    }
}
