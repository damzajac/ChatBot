# ChatBot

The application allows you to talk to a bot in real time, view the history of the conversation and rate its responses. While the bot is generating a response, it is possible to cancel this operation, so that only the text generated up to that point will be saved in the history, and the bot itself will stop generating a response.

The project was written in Clean Architecture using technologies including ASP.NET Core, EF Core, SQL Server and MediatR. SSE (Server Sent Events) was used for live communication.
An example of live events returned during response generation:

![EventStream](https://github.com/user-attachments/assets/8a377403-4fb0-418e-a6db-fd1d496ad3a3)

The current bot model generates random responses using the NLipsum library. To substitute the implementation of the real bot, it is enough to implement the IGenerateChatAnswerService interface.
