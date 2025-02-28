using ChatBot.Domain.Entities;
using ChatBot.Domain.Repositories;
using ChatBot.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ChatBot.Infrastructure.Repositories
{
    public class ChatMessageRepository : IChatMessageRepository
    {
        private readonly ChatBotDbContext dbContext;

        public ChatMessageRepository(ChatBotDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Commit()
        {
            await dbContext.SaveChangesAsync();
        }

        public async Task Create(ChatMessage chatMessage)
        {
            await dbContext.ChatMessages.AddAsync(chatMessage);
        }

        public async Task<ChatMessage> Get(Guid id)
        {
            return await dbContext.ChatMessages.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<ChatMessage>> GetAll(int skip, int take)
        {
            return await dbContext.ChatMessages
                .OrderByDescending(x => x.CreatedAt)
                .Skip(skip)
                .Take(take)
                .ToListAsync();
        }
    }
}