using ChatBot.Application.DTOs;
using MediatR;

namespace ChatBot.Application.UseCases.Queries.GetChatMessages
{
    public class GetChatMessagesQuery : IRequest<IEnumerable<ChatMessageDto>>
    {
        public int? SkipMessagesNumber { get; set; }
        public int? TakeMessagesNumber { get; set; }
    }
}
