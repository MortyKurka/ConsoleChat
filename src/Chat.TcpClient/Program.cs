using System.Net;
using Chat.TcpClient;

Console.WriteLine("Приветствую, это клиент консольного чата\nВведите Ip и Port к которому хотите подключиться");
var client = new TcpChatClient();

client.OnMessageReceived += (message) => {Console.WriteLine($"[Новое сообщение] {message}");};
client.OnConnect += () =>
{
    Console.WriteLine("\n===============");
    Console.WriteLine("Успешное подключение");
};
client.OnDisconnect += () =>
{
    Console.WriteLine("\nВы отключились");
    Console.WriteLine("До свидания");
};

while(!client.IsOnline)
{
    try
    {
        IPAddress? ip;
        int port;
        Console.Write("Ip> ");
        while(!IPAddress.TryParse(Console.ReadLine(),out ip))
        {
            Console.WriteLine("Ip адрес должен быть подобен следующему виду: 192.168.0.1");
            Console.Write("Ip> ");
        }


        Console.Write("Port> ");
        while(!int.TryParse(Console.ReadLine(), out port))
        {
            Console.WriteLine("Port должен быть числом от 0 до 65535");
            Console.Write("Port> ");
        }
        
        Console.WriteLine($"Подключение к {ip}:{port}");
        await client.ConnectAsync(ip, port);
    }
    catch(Exception ex)
    {
        Console.WriteLine($"Ошибка: {ex.Message}");
    }
}
while(client.IsOnline)
{
    var input = Console.ReadLine();

    if(input=="/quit")
    {
        await client.DisconnectAsync();
        break;
    }
    await client.SendAsync(input);
}

Console.WriteLine("=============");