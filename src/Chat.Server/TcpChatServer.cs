using System.Net;
using System.Net.Sockets;
using System.Text;
using Chat.Shared;

namespace Chat.Server;


/// <summary>
/// TCP chat server that handles client connections and message broadcasting.
/// </summary>
public class TcpChatServer
{
    private static int _count = 0;
    private TcpListener? _listener;
    private List<TcpClient> _clients = new List<TcpClient>();
    private bool _isOnline = false;
    public bool IsOnline => _isOnline;

    public TcpChatServer()
    {
    }

    public async Task StartAsync(IPAddress ip, int port)
    {
        _listener = new TcpListener(ip, port);
        _listener.Start();
        while(true)
        {
            TcpClient client = await _listener.AcceptTcpClientAsync();
            _clients.Add(client);
            _count++;
            Console.WriteLine("Подключение: "+_count);
            _ = Task.Run (() => HandleClient(client));
        }
    }
    public async Task HandleClient(TcpClient client)
    {
        while(client.Connected)
        {
            StreamReader reader = new StreamReader(client.GetStream(), Encoding.UTF8);
            string? message = await reader.ReadLineAsync();
            Broadcast(message);
        }
    }
    private void Broadcast(string message)
    {
        foreach(TcpClient client in _clients)
        {
            StreamWriter writer = new StreamWriter(client.GetStream(), Encoding.UTF8);
            writer.AutoFlush = true;
            writer.WriteLineAsync(new Message(message).ToString());
        }
    }
    
}