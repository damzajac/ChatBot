using FluentValidation;

namespace ChatBot.Application.UseCases.Commands.CreateChatMessage
{
    public class CreateChatMessageCommandValidator : AbstractValidator<CreateChatMessageCommand>
    {
        public CreateChatMessageCommandValidator()
        {
            RuleFor(x => x.Question)
                .NotEmpty();
        }
    }
}