using ChatBot.Application.Services;
using ChatBot.Domain.Entities;
using ChatBot.Domain.Repositories;
using MediatR;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;

namespace ChatBot.Application.UseCases.Commands.CreateChatMessage
{
    public class CreateChatMessageCommandHandler : IStreamRequestHandler<CreateChatMessageCommand, CreateChatMessageCommandResponse>
    {
        private const string ChatMessageIdGeneratedEventName = "idGenerated";
        private const string AnswerLineGeneratedEventName = "lineGenerated";
        private readonly IChatMessageRepository chatMessageRepository;
        private readonly IGenerateChatAnswerService generateChatAnswerService;

        public CreateChatMessageCommandHandler(IChatMessageRepository chatMessageRepository,
            IGenerateChatAnswerService generateChatAnswerService)
        {
            this.chatMessageRepository = chatMessageRepository;
            this.generateChatAnswerService = generateChatAnswerService;
        }

        public async IAsyncEnumerable<CreateChatMessageCommandResponse> Handle(CreateChatMessageCommand request, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var id = Guid.NewGuid();
            yield return new CreateChatMessageCommandResponse(ChatMessageIdGeneratedEventName, JsonSerializer.Serialize(new { id }));

            var answerBuilder = new StringBuilder();
            await foreach (var text in generateChatAnswerService.Generate(request.Question, cancellationToken))
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    break;
                }

                answerBuilder.Append(text);
                yield return new CreateChatMessageCommandResponse(AnswerLineGeneratedEventName, JsonSerializer.Serialize(new { text }));
            }

            var chatMessage = new ChatMessage
            {
                Id = id,
                CreatedAt = DateTime.UtcNow,
                Question = request.Question,
                Answer = answerBuilder.Length == 0 ? null : answerBuilder.ToString(),
                IsLiked = null
            };
            
            await chatMessageRepository.Create(chatMessage);
            await chatMessageRepository.Commit();
        }
    }
}
