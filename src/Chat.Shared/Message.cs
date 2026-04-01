namespace Chat.Shared;
/// <summary>
/// record для хранения сообщений
/// </summary>
/// <param name="Content">The message content.</param>
public record Message
(
    string? Content
)
{
    /// <summary>
    /// Time to send the message
    /// </summary>
    public DateTime TimeStamp { get; } = DateTime.Now;
    /// <summary>
    /// Converts a message to a string
    /// </summary>
    /// <returns>Returns the message as a string</returns>
    public override string ToString()
    {
        return $"[{TimeStamp:HH:mm:ss}] {Content}";
    }
}