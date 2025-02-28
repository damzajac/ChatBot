using ChatBot.Application.Services;
using ChatBot.Domain.Repositories;
using ChatBot.Infrastructure.Data;
using ChatBot.Infrastructure.Repositories;
using ChatBot.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace ChatBot.Web.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddScoped<IChatMessageRepository, ChatMessageRepository>()
                .AddScoped<IGenerateChatAnswerService, LoremIpsumChatAnswerGeneratorService>();

            services.AddDbContext<ChatBotDbContext>(opt
                => opt.UseSqlServer(configuration.GetConnectionString("ChatBotConnectionString")));

            return services;
        }
    }
}
