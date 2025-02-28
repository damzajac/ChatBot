using ChatBot.Domain.Entities;

namespace ChatBot.Domain.Repositories
{
    public interface IChatMessageRepository
    {
        Task Create(ChatMessage chatMessage);
        Task<ChatMessage> Get(Guid id);
        Task<IEnumerable<ChatMessage>> GetAll(int skip, int take);
        Task Commit();
    }
}
