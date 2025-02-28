using MediatR;

namespace ChatBot.Application.UseCases.Commands.CreateChatMessage
{
    public class CreateChatMessageCommand : IStreamRequest<CreateChatMessageCommandResponse>
    {
        public string Question { get; set; }
    }
}
