using System.Net;
using System.Net.Sockets;
using System.Text;

public class TcpChatClient : IClient
{
    /// <summary>
    /// Incoming message event
    /// </summary>
    public event Action<string?>? OnMessageReceived;
    /// <summary>
    /// User connection event
    /// </summary>
    public event Action? OnConnect;
    /// <summary>
    /// User disconnection event
    /// </summary>
    public event Action? OnDisconnect;

    private StreamWriter? _writer;
    private StreamReader? _reader;
    private TcpClient? _client;
    private bool _isOnline = false;
    public bool IsOnline => _isOnline;

    public TcpChatClient()
    {
    }
    
    public async Task ConnectAsync(IPAddress ip, int port)
    {
        if (IsOnline) return;
        try
        {
            _client = new TcpClient();
            using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            await _client.ConnectAsync(ip, port).WaitAsync(cts.Token);
            var stream = _client.GetStream();
            _reader = new StreamReader(stream, Encoding.UTF8);
            _writer = new StreamWriter(stream, Encoding.UTF8);
            _isOnline = true;
            OnConnect?.Invoke();
            _ = Task.Run(() => ReceiveLoopAsync());
            
        }
        catch(OperationCanceledException)
        {
            throw new TimeoutException("Не удалось подключиться к серверу за 10 секунд");
        }
    
    }
    public async Task DisconnectAsync()
    {
        if (!IsOnline) return;
        _writer.Dispose();
        _reader.Dispose();
        _client?.Close();
        _client.Dispose();

        _writer = null;
        _reader = null;
        _client = null;

        _isOnline = false;
        OnDisconnect?.Invoke();
    }
    public async Task ReceiveLoopAsync()
    {
        while (IsOnline && _reader!=null)
        {
            var msg = await _reader.ReadLineAsync();
            OnMessageReceived?.Invoke(msg);
        }
    }
    public async Task SendAsync(string message)
    {
        await _writer.WriteLineAsync(message);
        await _writer.FlushAsync();
    }
}