namespace Chat.Shared;
/// <summary>
/// An interface for representing an entity that can communicate
/// </summary>
public interface ICommunicator
{
    /// <summary>
    /// Displays whether an entity is online
    /// </summary>
    public bool IsOnline { get; }
    /// <summary>
    /// Data sending method
    /// </summary>
    /// <param name="msg"></param>
    Task SendAsync(string msg);
    /// <summary>
    /// Message reception cycle
    /// </summary>
    Task ReceiveLoopAsync();
}