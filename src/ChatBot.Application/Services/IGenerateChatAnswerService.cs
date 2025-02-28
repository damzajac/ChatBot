﻿namespace ChatBot.Application.Services
{
    public interface IGenerateChatAnswerService
    {
        IAsyncEnumerable<string> Generate(string question, CancellationToken cancellationToken);
    }
}
