using ChatBot.Domain.Entities;
using ChatBot.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace ChatBot.Infrastructure.Data
{
    public class ChatBotDbContext(DbContextOptions<ChatBotDbContext> options) : DbContext(options)
    {
        public DbSet<ChatMessage> ChatMessages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(ChatMessageConfiguration).Assembly);
        }
    }
}