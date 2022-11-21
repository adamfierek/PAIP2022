using ChatModel;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace ChatClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Write("Enter username: ");
            var userName = Console.ReadLine();

            var url = "http://127.0.0.1:5000/chat";

            HubConnection connection = new HubConnectionBuilder()
                .WithUrl(url)
                .Build();

            connection.On<Message>("ReceiveMessage", message =>
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{message.Sender}: ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(message.Content);
            });

            connection.On<string>("HelloMessage", message =>
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"{message} joined chat");
                Console.ForegroundColor = ConsoleColor.White;
            });

            await connection.StartAsync();

            await connection.SendAsync("Hello", userName);

            var line = "";

            do
            {
                line = Console.ReadLine();
                if (line == "/exit")
                {
                    return;
                }
                if (line != "")
                {
                    await connection.SendAsync("SendMessage", new Message 
                    {
                        Sender = userName,
                        Content = line
                    });
                }
            }
            while (true);
            ;
        }
    }
}
