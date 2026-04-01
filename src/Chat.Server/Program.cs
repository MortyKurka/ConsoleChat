using System.Net;

Console.WriteLine("Приветствую, это сервер консольного чата\nВведите Port на котором будет работать сервер");
var server = new TcpChatServer();
int port;
Console.Write("> ");
while(!int.TryParse(Console.ReadLine(), out port))
{
    Console.WriteLine("Порт должен быть целым числом");
    Console.Write("> ");
}
await server.StartAsync(IPAddress.Any, port);
while(true);