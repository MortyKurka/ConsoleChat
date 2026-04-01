using System.Net;

public interface IClient : ICommunicator
{
    public Task ConnectAsync(IPAddress ip, int port);
    public Task DisconnectAsync();
}