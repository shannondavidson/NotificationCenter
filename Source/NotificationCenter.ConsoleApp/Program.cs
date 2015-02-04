using Boilerplate.Core.Cqrs;
using NotificationCenter.Core.Commands;
using NotificationCenter.Core.Domain;
using NotificationCenter.Core.Sessions;

namespace NotificationCenter.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var message = new Message();
            message.From = "shannon.davidson@gmail.com";
            message.To = "scdavidso@hotmail.com";
            message.Subject = "Test Message";
            message.Body = "Test Body";

            var command = new MessageCreateCommand { Message = message };
            var commandProcessor = new CommandProcessor(new MessagingSqlSession());
            message = commandProcessor.Execute(command);

            var deleteCommand = new MessageDeleteCommand { MessageId = message.Id };
            commandProcessor.Execute(deleteCommand);
        }
    }
}
