using System.Net;
using Chat.Shared;

namespace Chat.TcpClient;

public interface IClient : ICommunicator
{
    public Task ConnectAsync(IPAddress ip, int port);
    public Task DisconnectAsync();
}